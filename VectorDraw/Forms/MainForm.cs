using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using Geometry;

namespace VectorDraw.Forms {
	public partial class MainForm : Form {
		enum EDIT_STATE {
			MASK_STATE = 0b11,

			STATE_BEGIN = 0b01,
			STATE_POST = 0b10,
			STATE_TARGET = 0b11,

			MODEL_ORIGIN = 0b00,

			TYPE_SELECT = 0b1_00,
			SELECT_BEGIN = TYPE_SELECT | STATE_BEGIN,
			SELECT_POST = TYPE_SELECT | STATE_POST,

			TYPE_CORNER = 0b10_00,
			CORNER_BEGIN = TYPE_CORNER | STATE_BEGIN,
			CORNER_POST = TYPE_CORNER | STATE_POST,

			TYPE_POLYLINE = 0b100_00,
			POLYLINE_BEGIN = TYPE_POLYLINE | STATE_BEGIN,
			POLYLINE_POST = TYPE_POLYLINE | STATE_POST,

			TYPE_POLYGON = 0b1000_00,
			POLYGON_BEGIN = TYPE_POLYGON | STATE_BEGIN,
			POLYGON_POST = TYPE_POLYGON | STATE_POST,

			TYPE_POLYHOLE = 0b10000_00,
			POLYHOLE_TARGET = TYPE_POLYHOLE | STATE_TARGET,
			POLYHOLE_BEGIN = TYPE_POLYHOLE | STATE_BEGIN,
			POLYHOLE_POST = TYPE_POLYHOLE | STATE_POST,
		}

		enum POLY_MODE {
			LINE,

			ARC_RADIUS,
			ARC_CENTER,
			ARC_SWEEP,

			BOW_END,
			BOW_RADIUS
		}

		public static Group CurrentGroup = null;

		bool mSizeChange = false;
		EDIT_STATE mEditState = EDIT_STATE.SELECT_BEGIN;
		POLY_MODE mPolyMode = POLY_MODE.LINE;
		BasePolygon mCurrentPolygon = null;

		public class GridValues {
			public int Pix;
			public double Scale;
		}
		GridValues mGlobalGrid = new GridValues() {
			Pix = 4,
			Scale = 2.54
		};

		Bitmap mBmp;
		Graphics mG;
		Point mOffset;
		Point mMousePos;
		PointF mCursor;
		BaseGeometry mDragPost = null;
		BaseGeometry mHoverPost = null;
		List<BaseGeometry> mPostList = new List<BaseGeometry>();
		List<Model> mModelList = new List<Model>();
		List<Layer> mLayerList = new List<Layer>();

		public MainForm() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			SizeChange();
			Layer.Add(mLayerList);
			Model.Add(mModelList);
			Group.Add(mModelList[0], mLayerList[0]);
			CurrentGroup = mModelList[0].Groups[0];
			KeyPreview = true;
			MenuItemMode_Select.PerformClick();
			MenuItemSnap_Grid.PerformClick();
			DisplayTimer.Enabled = true;
			DisplayTimer.Interval = 25;
			DisplayTimer.Start();
		}

		private void Form1_SizeChanged(object sender, EventArgs e) {
			mSizeChange = true;
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
			case Keys.Escape:
				MenuItemEdit_Cancel_Click(null, null);
				break;
			}
		}

		private void ScrollBarX_Scroll(object sender = null, ScrollEventArgs e = null) {
			mOffset.X = ScrollBarX.Value;
		}

		private void ScrollBarY_Scroll(object sender = null, ScrollEventArgs e = null) {
			mOffset.Y = -ScrollBarY.Value;
		}

		#region メニューイベント[ファイル]
		private void MenuItemFile_New_Click(object sender, EventArgs e) {
		}

		private void MenuItemFile_Open_Click(object sender, EventArgs e) {
			openFileDialog1.FileName = Path.GetFileNameWithoutExtension(Text);
			openFileDialog1.Filter = "XMLファイル(*.xml)|*.xml";
			openFileDialog1.ShowDialog();
			LoadFile(openFileDialog1.FileName);
		}

		private void MenuItemFile_Overwrite_Click(object sender, EventArgs e) {
			SaveFile(Text);
		}

		private void MenuItemFile_Save_Click(object sender, EventArgs e) {
			saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Text);
			saveFileDialog1.Filter = "XMLファイル(*.xml)|*.xml";
			saveFileDialog1.ShowDialog();
			SaveFile(saveFileDialog1.FileName);
		}

		private void MenuItemFile_SavePDF_Click(object sender, EventArgs e) {
		}

		void SaveFile(string path) {
			if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
				return;
			}
			var xml = XmlWriter.Create(path, new XmlWriterSettings { Indent = true, IndentChars = "\t" });
			xml.WriteStartDocument();
			xml.WriteStartElement("symbol");

			xml.WriteStartElement("layers");
			foreach (var item in mLayerList) {
				item.Write(xml);
			}
			xml.WriteEndElement();

			xml.WriteStartElement("models");
			foreach (var item in mModelList) {
				item.Write(xml);
			}
			xml.WriteEndElement();

			xml.WriteEndElement();
			xml.WriteEndDocument();
			xml.Flush();
			xml.Close();
			xml.Dispose();
			Text = path;
		}

		void LoadFile(string path) {
			if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
				return;
			}
			
			mModelList.Clear();
			var xml = XmlReader.Create(path);
			while (xml.Read()) {
				if (xml.LocalName != "symbol") {
					continue;
				}
				while (xml.Read()) {
					if (xml.NodeType != XmlNodeType.Element) {
						continue;
					}
					switch (xml.LocalName) {
					case "layers":
						mLayerList.Clear();
						break;
					case Layer.TagName:
						mLayerList.Add(new Layer(xml));
						break;
					case "models":
						mModelList.Clear();
						break;
					case Model.TagName:
						mModelList.Add(new Model(xml));
						break;
					default:
						break;
					}
				}
			}
			xml.Close();
			xml.Dispose();
			foreach (var model in mModelList) {
				foreach (var group in model.Groups) {
					group.SetLayer(mLayerList);
				}
			}
			if (mLayerList.Count == 0) {
				Layer.Add(mLayerList);
			}
			if (mModelList.Count == 0) {
				Model.Add(mModelList);
				Group.Add(mModelList[0], mLayerList[0]);
			} else if (mModelList[0].Groups.Count == 0) {
				Group.Add(mModelList[0], mLayerList[0]);
			}
			CurrentGroup = mModelList[0].Groups[0];
			Text = path;
		}
		#endregion

		#region メニューイベント[編集]
		private void MenuItemEdit_Cancel_Click(object sender, EventArgs e) {
			switch (mEditState & ~EDIT_STATE.MASK_STATE) {
			case EDIT_STATE.TYPE_SELECT:
			case EDIT_STATE.TYPE_CORNER:
			case EDIT_STATE.TYPE_POLYLINE:
			case EDIT_STATE.TYPE_POLYGON:
				mEditState &= ~EDIT_STATE.MASK_STATE;
				mEditState |= EDIT_STATE.STATE_BEGIN;
				break;
			case EDIT_STATE.TYPE_POLYHOLE:
				mEditState &= ~EDIT_STATE.MASK_STATE;
				mEditState |= EDIT_STATE.STATE_TARGET;
				break;
			}
		}

		private void MenuItemEdit_Undo_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Redo_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Delete_Click(object sender, EventArgs e) {
			var idx = CurrentGroup.Items.FindIndex((item) => item.IsSelected(new vec2(mMousePos)));
			if (idx >= 0) {
				CurrentGroup.Items.RemoveAt(idx);
			}
		}

		private void MenuItemEdit_Cut_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Copy_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Paste_Click(object sender, EventArgs e) {
		}
		#endregion

		#region メニューイベント[表示]
		private void MenuItemDisp_MoveToObjectOrigin_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_MoveToGlobalOrigin_Click(object sender, EventArgs e) {
			ScrollBarX.Value = 0;
			ScrollBarY.Value = 0;
		}

		private void MenuItemDisp_100_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_ZoomIn_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_ZoomOut_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_SetGridPitch_Click(object sender, EventArgs e) {
			var fm = new GridSettings(mGlobalGrid);
			fm.StartPosition = FormStartPosition.CenterParent;
			fm.ShowDialog();
		}

		private void MenuItemDisp_ModelGrid_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_GlobalGrid_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_ModelList_Click(object sender, EventArgs e) {
			ModelList.Open(mModelList, mLayerList, Cursor.Position);
		}

		private void MenuItemDisp_LayerList_Click(object sender, EventArgs e) {
			LayerList.Open(mLayerList, Cursor.Position);
		}
		#endregion

		#region メニューイベント[モード]
		private void MenuItemMode_Select_Click(object sender, EventArgs e) {
			MenuItemMode_Polyline.Checked = false;
			MenuItemMode_PolygonFill.Checked = false;
			MenuItemMode_PolygonHole.Checked = false;

			MenuItemPolyMode_Line.Checked = false;
			MenuItemPolyMode_Line.Enabled = true;
			MenuItemPolyMode_Arc.Checked = false;
			MenuItemPolyMode_Arc.Enabled = true;
			MenuItemPolyMode_Bow.Checked = false;
			MenuItemPolyMode_Bow.Enabled = true;

			MenuItemMode_Select.Checked = false;
			MenuItemMode_Corner.Checked = false;
			MenuItemMode_MoveModelOrigin.Checked = false;

			var item = (ToolStripMenuItem)sender;
			item.Checked = true;

			if (item == MenuItemMode_Polyline) {
				mEditState = EDIT_STATE.POLYLINE_BEGIN;
				mPolyMode = POLY_MODE.LINE;
				MenuItemPolyMode_Line.Checked = true;
				return;
			}
			if (item == MenuItemMode_PolygonFill) {
				mEditState = EDIT_STATE.POLYGON_BEGIN;
				mPolyMode = POLY_MODE.LINE;
				MenuItemPolyMode_Line.Checked = true;
				return;
			}
			if (item == MenuItemMode_PolygonHole) {
				mEditState = EDIT_STATE.POLYHOLE_TARGET;
				mPolyMode = POLY_MODE.LINE;
				MenuItemPolyMode_Line.Checked = true;
				return;
			}

			MenuItemPolyMode_Line.Enabled = false;
			MenuItemPolyMode_Arc.Enabled = false;
			MenuItemPolyMode_Bow.Enabled = false;

			if (item == MenuItemMode_Select) {
				mEditState = EDIT_STATE.SELECT_BEGIN;
				return;
			}
			if (item == MenuItemMode_Corner) {
				mEditState = EDIT_STATE.CORNER_BEGIN;
				return;
			}
			if (item == MenuItemMode_MoveModelOrigin) {
				mEditState = EDIT_STATE.MODEL_ORIGIN;
				return;
			}
		}

		private void MenuItemPolyMode_Click(object sender, EventArgs e) {
			MenuItemPolyMode_Line.Checked = false;
			MenuItemPolyMode_Arc.Checked = false;
			MenuItemPolyMode_Bow.Checked = false;

			if (!(MenuItemMode_Polyline.Checked | MenuItemMode_PolygonFill.Checked | MenuItemMode_PolygonHole.Checked)) {
				return;
			}

			var item = (ToolStripMenuItem)sender;
			item.Checked = true;

			if (item == MenuItemPolyMode_Line) {
				mPolyMode = POLY_MODE.LINE;
				return;
			}
			if (item == MenuItemPolyMode_Arc) {
				mPolyMode = POLY_MODE.ARC_RADIUS;
				return;
			}
			if (item == MenuItemPolyMode_Bow) {
				mPolyMode = POLY_MODE.BOW_END;
				return;
			}
		}
		#endregion

		#region メニューイベント[スナップ]
		private void MenuItemSnap_Click(object sender, EventArgs e) {
			var item = (ToolStripMenuItem)sender;
			item.Checked = !item.Checked;
		}
		#endregion

		#region 描画エリアイベント
		private void DisplayArea_MouseDown(object sender, MouseEventArgs e) {
			switch (e.Button) {
			case MouseButtons.Left:
				switch (mEditState & ~EDIT_STATE.MASK_STATE) {
				case EDIT_STATE.TYPE_SELECT:
					switch (mEditState & EDIT_STATE.MASK_STATE) {
					case EDIT_STATE.STATE_BEGIN:
						mDragPost = mHoverPost;
						if (mHoverPost != null) {
							mDragPost.Parent.SetGripPost(mHoverPost);
							mEditState &= ~EDIT_STATE.MASK_STATE;
							mEditState |= EDIT_STATE.STATE_POST;
						}
						break;
					}
					break;
				}
				break;
			}
		}

		private void DisplayArea_MouseUp(object sender, MouseEventArgs e) {
			switch (e.Button) {
			case MouseButtons.Left:
				switch (mEditState & ~EDIT_STATE.MASK_STATE) {
				case EDIT_STATE.TYPE_SELECT:
					switch (mEditState & EDIT_STATE.MASK_STATE) {
					case EDIT_STATE.STATE_POST:
						mDragPost.Parent.SetGripPost(null);
						mDragPost = null;
						mEditState &= ~EDIT_STATE.MASK_STATE;
						mEditState |= EDIT_STATE.STATE_BEGIN;
						break;
					}
					break;
				case EDIT_STATE.TYPE_POLYLINE:
				case EDIT_STATE.TYPE_POLYGON:
					switch (mEditState & EDIT_STATE.MASK_STATE) {
					case EDIT_STATE.STATE_BEGIN:
						mPostList.Clear();
						mPostList.Add(new Post() { Pos = new vec2(mMousePos) });
						mEditState &= ~EDIT_STATE.MASK_STATE;
						mEditState |= EDIT_STATE.STATE_POST;
						break;
					case EDIT_STATE.STATE_POST:
						mPostList.Add(new Post() { Pos = new vec2(mMousePos) });
						break;
					}
					break;
				case EDIT_STATE.TYPE_POLYHOLE:
					switch (mEditState & EDIT_STATE.MASK_STATE) {
					case EDIT_STATE.STATE_TARGET:
						mCurrentPolygon = null;
						foreach (var item in CurrentGroup.Items) {
							if ((item is Polygon polygon) && item.IsSelected(new vec2(mMousePos))) {
								mCurrentPolygon = polygon;
								mEditState &= ~EDIT_STATE.MASK_STATE;
								mEditState |= EDIT_STATE.STATE_BEGIN;
								break;
							}
						}
						break;
					case EDIT_STATE.STATE_BEGIN:
						mPostList.Clear();
						mPostList.Add(new Post() { Pos = new vec2(mMousePos) });
						mEditState &= ~EDIT_STATE.MASK_STATE;
						mEditState |= EDIT_STATE.STATE_POST;
						break;
					case EDIT_STATE.STATE_POST:
						mPostList.Add(new Post() { Pos = new vec2(mMousePos) });
						break;
					}
					break;
				default:
					break;
				}
				break;
			case MouseButtons.Right:
				switch (mEditState) {
				case EDIT_STATE.POLYLINE_POST:
					mEditState = EDIT_STATE.POLYLINE_BEGIN;
					if (mPostList.Count >= 2) {
						CurrentGroup.Items.Add(new Polyline(mPostList, CurrentGroup));
					}
					break;
				case EDIT_STATE.POLYGON_POST:
					mEditState = EDIT_STATE.POLYGON_BEGIN;
					if (mPostList.Count >= 3) {
						CurrentGroup.Items.Add(new Polygon(mPostList, CurrentGroup));
					}
					break;
				case EDIT_STATE.POLYHOLE_POST:
					mEditState = EDIT_STATE.POLYHOLE_TARGET;
					if (mPostList.Count >= 3) {
						((Polygon)mCurrentPolygon).AddHole(mPostList);
					}
					break;
				default:
					Cursor.Show();
					break;
				}
				break;
			}
		}

		private void DisplayArea_MouseMove(object sender, MouseEventArgs e) {
			var unitPix = mGlobalGrid.Pix;
			var pos = DisplayArea.PointToClient(Cursor.Position);
			pos.X = mOffset.X + pos.X - DisplayArea.Width / 2;
			pos.Y = mOffset.Y + DisplayArea.Height / 2 - pos.Y;
			if (MenuItemSnap_Grid.Checked) {
				pos.X = pos.X / unitPix * unitPix;
				pos.Y = pos.Y / unitPix * unitPix;
			}
			mMousePos.X = pos.X + DisplayArea.Width / 2 - mOffset.X;
			mMousePos.Y = DisplayArea.Height / 2 + mOffset.Y - pos.Y;
			mCursor.X = (float)(pos.X * mGlobalGrid.Scale / unitPix);
			mCursor.Y = (float)(pos.Y * mGlobalGrid.Scale / unitPix);
			MenuTextPositionX.Text = mCursor.X.ToString(" 0.00;-0.00");
			MenuTextPositionY.Text = mCursor.Y.ToString(" 0.00;-0.00");
		}
		#endregion

		#region 描画更新
		private void DisplayTimer_Tick(object sender, EventArgs e) {
			if (mSizeChange) {
				SizeChange();
				mSizeChange = false;
			}
			MenuTextHint.Text = $"{CurrentGroup.Parent.Name}#{CurrentGroup.Name}[{CurrentGroup.Layer.Name}]";
			mG.Clear(Color.Black);

			mHoverPost = null;
			foreach (var layer in mLayerList) {
				foreach (var model in mModelList) {
					foreach (var group in model.Groups) {
						if (group.Layer != layer) {
							continue;
						}
						foreach (var item in group.Items) {
							if (group == CurrentGroup) {
								var post = item.GetPost(new vec2(mMousePos));
								if (post == null) {
									if (item.IsSelected(new vec2(mMousePos))) {
										item.DrawHighlight(mG);
									}
									else {
										item.Draw(mG);
									}
								}
								else {
									mHoverPost = post;
									item.Draw(mG);
								}
							}
							else {
								item.Draw(mG);
							}
						}
					}
				}
			}

			switch (mEditState & EDIT_STATE.MASK_STATE) {
			case EDIT_STATE.STATE_BEGIN:
				switch (mEditState & ~EDIT_STATE.MASK_STATE) {
				case EDIT_STATE.TYPE_SELECT:
					if (mHoverPost == null) {
						DrawCursor();
					}
					else {
						mHoverPost.DrawHighlight(mG);
					}
					break;
				default:
					DrawCursor();
					break;
				}
				break;
			case EDIT_STATE.STATE_POST:
				var list = new List<BaseGeometry>(mPostList);
				list.Add(new Post() { Pos = new vec2(mMousePos) });
				var poly = new PointF[list.Count];
				for (var i = 0; i < list.Count; i++) {
					poly[i] = list[i].Pos.Point;
				}
				switch (mEditState & ~EDIT_STATE.MASK_STATE) {
				case EDIT_STATE.TYPE_SELECT:
					if (mDragPost != null) {
						mDragPost.Pos = new vec2(mMousePos);
					}
					break;
				case EDIT_STATE.TYPE_POLYLINE:
					mG.DrawLines(Pens.Red, poly);
					break;
				case EDIT_STATE.TYPE_POLYGON:
					mG.FillPolygon(Brushes.Cyan, poly);
					mG.DrawPolygon(Pens.Red, poly);
					break;
				case EDIT_STATE.TYPE_POLYHOLE:
					mG.FillPolygon(Brushes.LightGray, poly);
					mG.DrawPolygon(Pens.Red, poly);
					break;
				}
				DrawCursor();
				break;
			}

			DisplayArea.Image = DisplayArea.Image;
		}

		void DrawCursor() {
			var xn = mMousePos.X;
			var yn = mMousePos.Y;
			var xa = xn - 7;
			var ya = yn - 7;
			var xb = xn + 7;
			var yb = yn + 7;
			mG.DrawLine(Pens.Red, xa, yn, xb, yn);
			mG.DrawLine(Pens.Red, xn, ya, xn, yb);
		}

		void SizeChange() {
			DisplayArea.Left = 0;
			DisplayArea.Top = menuStrip1.Bottom;
			DisplayArea.Width = Width - ScrollBarY.Width - 16;
			DisplayArea.Height = Height - ScrollBarX.Height - menuStrip1.Bottom - 39;

			ScrollBarY.Left = DisplayArea.Right;
			ScrollBarY.Top = menuStrip1.Bottom;
			ScrollBarY.Height = DisplayArea.Height;
			ScrollBarX.Left = 0;
			ScrollBarX.Top = DisplayArea.Bottom;
			ScrollBarX.Width = DisplayArea.Width;

			if (null != mG) {
				mG.Dispose();
				mG = null;
			}
			if (null != mBmp) {
				mBmp.Dispose();
				mBmp = null;
			}
			if (null != DisplayArea.Image) {
				DisplayArea.Image.Dispose();
				DisplayArea.Image = null;
			}

			mBmp = new Bitmap(Math.Max(MinimumSize.Width, DisplayArea.Width), Math.Max(MinimumSize.Height, DisplayArea.Height));
			mG = Graphics.FromImage(mBmp);
			DisplayArea.Image = mBmp;
			ScrollBarX_Scroll();
			ScrollBarY_Scroll();
		}
		#endregion
	}
}
