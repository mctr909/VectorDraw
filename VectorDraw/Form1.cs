using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Geometry;

namespace VectorDraw {
	public partial class Form1 : Form {
		enum EDIT_STATE {
			LOCAL_ORIGIN,

			SELECT_BEGIN,
			SELECT_GRIP,

			CORNER_SELECT,
			CORNER_RADIUS,

			POLYLINE_BEGIN,
			POLYLINE_POST,
			POLYLINE_END,

			POLYGON_BEGIN,
			POLYGON_POST,
			POLYGON_END,

			POLYHOLE_SELECT,
			POLYHOLE_BEGIN,
			POLYHOLE_POST,
			POLYHOLE_END
		}

		enum POLY_MODE {
			LINE,

			ARC_RADIUS,
			ARC_CENTER,
			ARC_SWEEP,

			BOW_END,
			BOW_RADIUS
		}

		bool mSizeChange = false;
		EDIT_STATE mEditState = EDIT_STATE.SELECT_BEGIN;
		POLY_MODE mPolyMode = POLY_MODE.LINE;

		Bitmap mBmp;
		Graphics mG;
		Point mOffset;
		Point mCursor;

		public Form1() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {
			SizeChange();
			KeyPreview = true;
			MenuItemMode_Select.PerformClick();
			DisplayTimer.Enabled = true;
			DisplayTimer.Interval = 16;
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
			mOffset.Y = ScrollBarY.Value;
		}

		#region メニューイベント[ファイル]
		private void MenuItemFile_New_Click(object sender, EventArgs e) {
		}

		private void MenuItemFile_Open_Click(object sender, EventArgs e) {
			openFileDialog1.FileName = Path.GetFileNameWithoutExtension(Text);
			openFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
			openFileDialog1.ShowDialog();
			LoadFile(openFileDialog1.FileName);
		}

		private void MenuItemFile_Overwrite_Click(object sender, EventArgs e) {
			SaveFile(Text);
		}

		private void MenuItemFile_Save_Click(object sender, EventArgs e) {
			saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(Text);
			saveFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
			saveFileDialog1.ShowDialog();
			SaveFile(saveFileDialog1.FileName);
		}

		private void MenuItemFile_SavePDF_Click(object sender, EventArgs e) {
		}

		void SaveFile(string path) {
			if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
				return;
			}
			var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
			var sw = new StreamWriter(fs);
			sw.Flush();
			sw.Close();
			sw.Dispose();
			Text = path;
		}

		void LoadFile(string path) {
			if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
				return;
			}
			var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			var sr = new StreamReader(fs);
			sr.Close();
			sr.Dispose();
			Text = path;
		}
		#endregion

		#region メニューイベント[編集]
		private void MenuItemEdit_Cancel_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Undo_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Redo_Click(object sender, EventArgs e) {
		}

		private void MenuItemEdit_Delete_Click(object sender, EventArgs e) {
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
		}

		private void MenuItemDisp_ObjectGrid_Click(object sender, EventArgs e) {
		}

		private void MenuItemDisp_GlobalGrid_Click(object sender, EventArgs e) {
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
			MenuItemMode_MoveObjectOrigin.Checked = false;

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
				mEditState = EDIT_STATE.POLYHOLE_SELECT;
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
				mEditState = EDIT_STATE.CORNER_SELECT;
				return;
			}
			if (item == MenuItemMode_MoveObjectOrigin) {
				mEditState = EDIT_STATE.LOCAL_ORIGIN;
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
		}

		private void DisplayArea_MouseUp(object sender, MouseEventArgs e) {
		}

		private void DisplayArea_MouseMove(object sender, MouseEventArgs e) {
			mCursor = DisplayArea.PointToClient(Cursor.Position);
			//tslPos.Text = string.Format("{0}mm, {1}mm", mCursor.X.ToString("0.##"), mCursor.Y.ToString("0.##"));
		}
		#endregion

		#region 描画更新
		private void DisplayTimer_Tick(object sender, EventArgs e) {
			if (mSizeChange) {
				SizeChange();
				mSizeChange = false;
			}
			mG.Clear(Color.Black);

			DisplayArea.Image = DisplayArea.Image;
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
