using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VectorDraw {
    public partial class Form1 : Form {
        enum MODE {
            SELECT,
            MOVE_ORIGIN,
            POLYLINE,
            POLYGON_FILL,
            POLYGON_HOLE
        }

        MODE mMode = MODE.SELECT;
        int mDispScale = 1;
        bool mSizeChange = false;
        Bitmap mBmp;
        Graphics mG;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            sizeChange();
            KeyPreview = true;
            timer1.Interval = 33;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) {
            mSizeChange = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
            case Keys.Escape:
                tsmEditEsc_Click(sender, e);
                break;
            }
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
            load(path);
        }

        private void tsmFileOverwrite_Click(object sender, EventArgs e) {

        }

        private void tsmFileSave_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            var path = saveFileDialog1.FileName;
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
                return;
            }
            save(path);
        }

        private void tsmFileSavePDF_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Menu[Edit] events
        private void tsmEditUndo_Click(object sender, EventArgs e) {

        }

        private void tsmEditRedo_Click(object sender, EventArgs e) {

        }

        private void tsmEditEsc_Click(object sender, EventArgs e) {
        }

        private void tsmEditCut_Click(object sender, EventArgs e) {

        }

        private void tsmEditCopy_Click(object sender, EventArgs e) {

        }

        private void tsmEditPaste_Click(object sender, EventArgs e) {

        }

        private void tsmEditDelete_Click(object sender, EventArgs e) {
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
            mDispScale = 1;
        }

        private void tsmDispZoomIn_Click(object sender, EventArgs e) {
            if (mDispScale < 16) {
                mDispScale++;
            }
        }

        private void tsmDispZoomOut_Click(object sender, EventArgs e) {
            if (1 < mDispScale) {
                mDispScale--;
            }
        }

        private void tsmDispSetGridPitch_Click(object sender, EventArgs e) {

        }

        private void tsmDispLocalGrid_Click(object sender, EventArgs e) {

        }

        private void tsmDispGlobalGrid_Click(object sender, EventArgs e) {

        }
        #endregion

        private void tsmSnap_Click(object sender, EventArgs e) {
            var obj = (ToolStripMenuItem)sender;
            obj.Checked = !obj.Checked;
        }

        private void tsmMode_Click(object sender, EventArgs e) {
            tsmModeSelect.Checked = false;
            tsmModeMoveLocalOrigin.Checked = false;
            tsmModePolyline.Checked = false;
            tsmModePolygonFill.Checked = false;
            tsmModePolygonHole.Checked = false;
            var obj = (ToolStripMenuItem)sender;
            if (obj == tsmModeSelect) {
                obj.Checked = true;
                mMode = MODE.SELECT;
                return;
            }
            if (obj == tsmModeMoveLocalOrigin) {
                obj.Checked = true;
                mMode = MODE.MOVE_ORIGIN;
                return;
            }
            if (obj == tsmModePolyline) {
                obj.Checked = true;
                mMode = MODE.POLYLINE;
                return;
            }
            if (obj == tsmModePolygonFill) {
                obj.Checked = true;
                mMode = MODE.POLYGON_FILL;
                return;
            }
            if (obj == tsmModePolygonHole) {
                obj.Checked = true;
                mMode = MODE.POLYGON_HOLE;
                return;
            }
        }

        #region PictureBox events
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            var pos = pictureBox1.PointToClient(Cursor.Position);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            var pos = pictureBox1.PointToClient(Cursor.Position);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            var pos = pictureBox1.PointToClient(Cursor.Position);
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e) {
            if (mSizeChange) {
                sizeChange();
            }

            mG.Clear(Color.Transparent);

            drawEditingLine();
            drawLine();

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

        void drawLine() {
        }

        void drawEditingLine() {
        }

        bool pointOnLine(PointF[] line, PointF p) {
            return false;
        }

        bool pointOnLine(PointF a, PointF b, PointF p, int limitDist = 5) {
            var abx = b.X - a.X;
            var aby = b.Y - a.Y;
            var apx = p.X - a.X;
            var apy = p.Y - a.Y;
            var abL2 = abx * abx + aby * aby;
            PointF q;
            if (0 == abL2) {
                q = a;
            } else {
                var r = (apx * abx + apy * aby) / abL2;
                if (r <= 0.0) {
                    q = a;
                } else if (1.0 <= r) {
                    q = b;
                } else {
                    q = new PointF(abx * r + a.X, aby * r + a.Y);
                }
            }
            var pqx = q.X - p.X;
            var pqy = q.Y - p.Y;
            var pqL2 = pqx * pqx + pqy * pqy;
            return pqL2 < limitDist * limitDist;
        }
    }
}
