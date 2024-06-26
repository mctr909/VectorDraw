﻿using System;
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
            ARC_POS,
            ARC_RADIUS,
            ARC_BEGIN,
            ARC_END,
            BOW_BEGIN,
            BOW_END,
            BOW_RADIUS,
            POLYLINE
        }

        Bitmap mBmp;
        Graphics mG;
        bool mSizeChange = false;
        Point mScroll = new Point();
        Point mCursor = new Point();
        MOUSE_MODE mMode = MOUSE_MODE.SELECT;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            sizeChange();
            KeyPreview = true;
            timer1.Enabled = true;
            timer1.Interval = 16;
            timer1.Start();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            mSizeChange = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            switch(e.KeyCode) {
            case Keys.Escape:
                tsmEditEsc_Click(null, null);
                break;
            }
        }

        private void hScrollBar1_Scroll(object sender = null, ScrollEventArgs e = null) {
            mScroll.X = hScrollBar1.Value;
        }

        private void vScrollBar1_Scroll(object sender = null, ScrollEventArgs e = null) {
            mScroll.Y = vScrollBar1.Value;
        }

        #region Menu[File] events
        private void tsmFileNew_Click(object sender, EventArgs e) {
        }

        private void tsmFileOpen_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
            openFileDialog1.ShowDialog();
            var path = openFileDialog1.FileName;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
                return;
            }
            Text = path;
            load(path);
        }

        private void tsmFileOverwrite_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(Text) || !Directory.Exists(Path.GetDirectoryName(Text))) {
                return;
            }
            save(Text);
        }

        private void tsmFileSave_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            var path = saveFileDialog1.FileName;
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
                return;
            }
            Text = path;
            save(path);
        }

        private void tsmFileSavePDF_Click(object sender, EventArgs e) {
        }
        #endregion

        #region Menu[Edit] events
        private void tsmEditEsc_Click(object sender, EventArgs e) {
        }

        private void tsmEditUndo_Click(object sender, EventArgs e) {
        }

        private void tsmEditRedo_Click(object sender, EventArgs e) {
        }

        private void tsmEditSelect_Click(object sender, EventArgs e) {
            tsmEditSelect.Checked = false;
            tsmModeMoveLocalOrigin.Checked = false;
            tsmModePolyline.Checked = false;
            tsmModePolygonFill.Checked = false;
            tsmModePolygonHole.Checked = false;

            var item = (ToolStripMenuItem)sender;

            if (item == tsmEditSelect) {
                //mMode = MODE.SELECT;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }

            item.Checked = true;

            if (item == tsmModeMoveLocalOrigin) {
                //mMode = MODE.MOVE_ORIGIN;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }
            if (item == tsmModePolyline) {
                //mMode = MODE.POLYLINE;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }
            if (item == tsmModePolygonFill) {
                //mMode = MODE.POLYGON_FILL;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }
            if (item == tsmModePolygonHole) {
                //mMode = MODE.POLYGON_HOLE;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }
        }

        private void tsmEditDelete_Click(object sender, EventArgs e) {
        }

        private void tsmEditCut_Click(object sender, EventArgs e) {
        }

        private void tsmEditCopy_Click(object sender, EventArgs e) {
        }

        private void tsmEditPaste_Click(object sender, EventArgs e) {
        }
        #endregion

        #region Menu[Display] events
        private void tsmDispMoveToLocalOrigin_Click(object sender, EventArgs e) {
        }

        private void tsmDispMoveToGlobalOrigin_Click(object sender, EventArgs e) {
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;
        }

        private void tsmDisp100_Click(object sender, EventArgs e) {
        }

        private void tsmDispZoomIn_Click(object sender, EventArgs e) {
        }

        private void tsmDispZoomOut_Click(object sender, EventArgs e) {
        }

        private void tsmDispSetGridPitch_Click(object sender, EventArgs e) {
        }

        private void tsmDispLocalGrid_Click(object sender, EventArgs e) {
        }

        private void tsmDispGlobalGrid_Click(object sender, EventArgs e) {
        }
        #endregion

        private void tsmSnap_Click(object sender, EventArgs e) {
            var item = (ToolStripMenuItem)sender;
            item.Checked = !item.Checked;
        }

        #region PictureBox events
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            mCursor = pictureBox1.PointToClient(Cursor.Position);
            //tslPos.Text = string.Format("{0}mm, {1}mm", mCursor.X.ToString("0.##"), mCursor.Y.ToString("0.##"));
        }
        #endregion

        int cnt = 0;
        const int DELTA = 480;

        private void timer1_Tick(object sender, EventArgs e) {
            if (mSizeChange) {
                sizeChange();
                mSizeChange = false;
            }
            mG.Clear(Color.Black);

			//{
			//	var c = new Geometry.Rectangle();
			//	c.Pa.X = 400;
			//	c.Pa.Y = 300;
			//	c.Pb.X = 410;
			//	c.Pb.Y = 310;
			//	var th = 2 * Math.PI * cnt / DELTA + Math.PI / 2;
			//	c.Pb.X = c.Pa.X + 300 * (float)Math.Cos(th);
			//	c.Pb.Y = c.Pa.Y + 300 * (float)Math.Sin(th);
			//	c.Thickness = Geometry.Rectangle.LastThickness;
			//	c.Calc();
			//	c.Draw(mG, c.IsSelected(mCursor));
			//}

			{
				var c = new Arrow();
				c.Pa.X = 400;
				c.Pa.Y = 300;
				c.Pb.X = 410;
				c.Pb.Y = 310;
				var th = 2 * Math.PI * cnt / DELTA + Math.PI / 2;
				c.Pb.X = c.Pa.X + 300 * (float)Math.Cos(th);
				c.Pb.Y = c.Pa.Y + 300 * (float)Math.Sin(th);
				c.Length = Arrow.LastLength;
				c.Width = Arrow.LastWidth;
				c.Thickness = Arrow.LastThickness;
				c.Calc();
				c.Draw(mG, c.IsSelected(mCursor));
			}

			{
				var c = new Arc();
				c.Po.X = 300;
				c.Po.Y = 400;
				c.Radius = 120;
				c.Sweep = 45;
				c.Begin = 360 * cnt / DELTA + 45;
				c.Draw(mG, c.IsSelected(mCursor));
				var opx = mCursor.X - c.Po.X;
				var opy = mCursor.Y - c.Po.Y;
				var opr = Math.Sqrt(opx * opx + opy * opy);
				var op_arg = Math.Atan2(opy, opx) * 180 / Math.PI;
				tslPos.Text = string.Format("R:{0}, θ:{1}", opr.ToString("g3"), op_arg.ToString("g3"));
				c.Begin = 360 * cnt / DELTA + 180;
				c.Draw(mG, c.IsSelected(mCursor));
			}

			{
				var c = new Corner();
				c.Po.X = 200;
				c.Po.Y = 200;
				c.Pa.X = 400;
				c.Pa.Y = 400;
				c.Radius = Corner.LastRadius;
				var th = 2 * Math.PI * cnt / DELTA + Math.PI / 2;
				c.Pb.X = c.Po.X + 300 * (float)Math.Cos(th);
				c.Pb.Y = c.Po.Y + 300 * (float)Math.Sin(th);
				c.Calc();
				c.Draw(mG, c.IsSelected(mCursor));
			}

			cnt = (++cnt % DELTA);
            pictureBox1.Image = pictureBox1.Image;
        }

        void sizeChange() {
            mSizeChange = false;

            pictureBox1.Left = 0;
            pictureBox1.Top = menuStrip1.Bottom;
            pictureBox1.Width = Width - vScrollBar1.Width - 16;
            pictureBox1.Height = Height - menuStrip1.Bottom - statusStrip1.Height - 56;

            vScrollBar1.Left = pictureBox1.Right;
            vScrollBar1.Top = menuStrip1.Bottom;
            vScrollBar1.Height = pictureBox1.Height;
            hScrollBar1.Left = 0;
            hScrollBar1.Top = pictureBox1.Bottom;
            hScrollBar1.Width = pictureBox1.Width;

            if (null != mG) {
                mG.Dispose();
                mG = null;
            }
            if (null != mBmp) {
                mBmp.Dispose();
                mBmp = null;
            }
            if (null != pictureBox1.Image) {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            mBmp = new Bitmap(Math.Max(MinimumSize.Width, pictureBox1.Width), Math.Max(MinimumSize.Height, pictureBox1.Height));
            mG = Graphics.FromImage(mBmp);
            pictureBox1.Image = mBmp;
            hScrollBar1_Scroll();
            vScrollBar1_Scroll();
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
