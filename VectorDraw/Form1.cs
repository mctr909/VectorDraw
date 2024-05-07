using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Geometry;

namespace VectorDraw {
	public partial class Form1 : Form {
		enum MOUSE_MODE {
			SELECT,
			GRIP_POST,
			GRIP_ITEMS,
			BEGIN,
			POS,
			RADIUS
		}

		Bitmap Bmp;
		Drawer G;
		bool SizeChange = false;
		Point Scroll = new Point();
		Point Cursor = new Point();
		MOUSE_MODE Mode = MOUSE_MODE.SELECT;

		public Form1() {
			InitializeComponent();
		}

		#region Form events
		private void Form1_Load(object sender, EventArgs e) {
			sizeChange();
			KeyPreview = true;
			timer1.Enabled = true;
			timer1.Interval = 16;
			timer1.Start();
		}

		private void Form1_SizeChanged(object sender, EventArgs e) {
			SizeChange = true;
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e) {
			switch (e.KeyCode) {
			case Keys.Escape:
				break;
			}
		}

		private void HSB_Scroll(object sender = null, ScrollEventArgs e = null) {
			Scroll.X = HSB.Value;
		}

		private void VSB_Scroll(object sender = null, ScrollEventArgs e = null) {
			Scroll.Y = VSB.Value;
		}
		#endregion

		#region PictureBox events
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
			Cursor = pictureBox1.PointToClient(System.Windows.Forms.Cursor.Position);
			//tslPos.Text = string.Format("{0}mm, {1}mm", mCursor.X.ToString("0.##"), mCursor.Y.ToString("0.##"));
		}
		#endregion

		#region Menu[File] events
		private void FileNew_Click(object sender, EventArgs e) {
		}

		private void FileOpen_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = "SVGファイル(*.svg)|*.svg";
			openFileDialog1.ShowDialog();
			var path = openFileDialog1.FileName;
			if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
				return;
			}
			Text = path;
			load(path);
		}

		private void FileOverwrite_Click(object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(Text) || !Directory.Exists(Path.GetDirectoryName(Text))) {
				return;
			}
			save(Text);
		}

		private void FileSave_Click(object sender, EventArgs e) {
			saveFileDialog1.Filter = "SVGファイル(*.svg)|*.svg";
			saveFileDialog1.ShowDialog();
			var path = saveFileDialog1.FileName;
			if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
				return;
			}
			Text = path;
			save(path);
		}
		#endregion

		#region Menu[Edit] events
		private void EditUndo_Click(object sender, EventArgs e) {
		}

		private void EditRedo_Click(object sender, EventArgs e) {
		}

		private void EditCut_Click(object sender, EventArgs e) {
		}

		private void EditCopy_Click(object sender, EventArgs e) {
		}

		private void EditPaste_Click(object sender, EventArgs e) {
		}

		private void EditDelete_Click(object sender, EventArgs e) {
		}
		#endregion

		#region Menu[Display] events
		private void Disp100_Click(object sender, EventArgs e) {
		}

		private void DispZoomIn_Click(object sender, EventArgs e) {
		}

		private void DispZoomOut_Click(object sender, EventArgs e) {
		}

		private void DispMoveToLocalOrigin_Click(object sender, EventArgs e) {
		}

		private void DispMoveToGlobalOrigin_Click(object sender, EventArgs e) {
			HSB.Value = 0;
			VSB.Value = 0;
		}

		private void DispLocalGrid_Click(object sender, EventArgs e) {
		}

		private void DispGlobalGrid_Click(object sender, EventArgs e) {
		}
		#endregion

		private void Mode_Click(object sender, EventArgs e) {
			ModeSelect.Checked = false;
			ModeMoveLocalOrigin.Checked = false;
			ModePolyline.Checked = false;
			ModePolygonFill.Checked = false;
			ModePolygonHole.Checked = false;

			var item = (ToolStripMenuItem)sender;
			item.Checked = true;

			if (item == ModeSelect) {
				EnableLineType(false);
				Mode = MOUSE_MODE.SELECT;
				return;
			}
			if (item == ModeMoveLocalOrigin) {
				EnableLineType(false);
				Mode = MOUSE_MODE.SELECT;
				return;
			}
			if (item == ModePolyline) {
				EnableLineType(true);
				Mode = MOUSE_MODE.BEGIN;
				return;
			}
			if (item == ModePolygonFill) {
				EnableLineType(true);
				Mode = MOUSE_MODE.BEGIN;
				return;
			}
			if (item == ModePolygonHole) {
				EnableLineType(true);
				Mode = MOUSE_MODE.BEGIN;
				return;
			}

			void EnableLineType(bool enable) {
				ModeLine.Enabled = enable;
				ModeCurve.Enabled = enable;
				ModeArc.Enabled = enable;
			}
		}

		private void ModeLineType_Click(object sender, EventArgs e) {
			ModeLine.Checked = false;
			ModeCurve.Checked = false;
			ModeArc.Checked = false;
			var item = (ToolStripMenuItem)sender;
			item.Checked = true;
		}

		private void Snap_Click(object sender, EventArgs e) {
			var item = (ToolStripMenuItem)sender;
			item.Checked = !item.Checked;
		}

		int cnt = 0;
		const int DELTA = 480;

		private void timer1_Tick(object sender, EventArgs e) {
			if (SizeChange) {
				sizeChange();
				SizeChange = false;
			}
			G.Clear(Color.Black);

			{
				var c = new Arc {
					A = new Vec2 { X = 400, Y = 400 },
					O = new Vec2 { X = 200, Y = 200 }
				};
				var th = 2 * Math.PI * cnt / DELTA + Math.PI / 2;
				c.B = c.O + Vec2.FromPhaser(300, th);
				c.Calc();
				c.Draw(G, c.IsSelected(Cursor));
			}

			cnt = (++cnt % DELTA);
			pictureBox1.Image = pictureBox1.Image;
		}

		void sizeChange() {
			SizeChange = false;

			pictureBox1.Left = 0;
			pictureBox1.Top = menuStrip1.Bottom;
			pictureBox1.Width = Width - VSB.Width - 16;
			pictureBox1.Height = Height - menuStrip1.Bottom - statusStrip1.Height - 56;

			VSB.Left = pictureBox1.Right;
			VSB.Top = menuStrip1.Bottom;
			VSB.Height = pictureBox1.Height;
			HSB.Left = 0;
			HSB.Top = pictureBox1.Bottom;
			HSB.Width = pictureBox1.Width;

			if (null != G) {
				G.Dispose();
				G = null;
			}
			if (null != Bmp) {
				Bmp.Dispose();
				Bmp = null;
			}
			if (null != pictureBox1.Image) {
				pictureBox1.Image.Dispose();
				pictureBox1.Image = null;
			}

			Bmp = new Bitmap(Math.Max(MinimumSize.Width, pictureBox1.Width), Math.Max(MinimumSize.Height, pictureBox1.Height));
			G = new Drawer(Bmp);
			pictureBox1.Image = Bmp;
			HSB_Scroll();
			VSB_Scroll();
		}

		void save(string path) {
			var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
			var sw = new StreamWriter(fs);
			sw.Flush();
			sw.Close();
			sw.Dispose();
		}

		void load(string path) {
			var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			var sr = new StreamReader(fs);
			sr.Close();
			sr.Dispose();
		}
	}
}
