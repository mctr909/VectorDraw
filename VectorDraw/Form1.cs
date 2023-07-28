using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorDraw {
    public partial class Form1 : Form {
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
                toolStripMenuItem_edit_esc_Click(sender, e);
                break;
            }
        }

        #region Menu[File] events
        private void toolStripMenuItem_file_new_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_file_open_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
            openFileDialog1.ShowDialog();
            var path = openFileDialog1.FileName;
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) {
                return;
            }
            load(path);
        }

        private void toolStripMenuItem_file_overwrite_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_file_save_Click(object sender, EventArgs e) {
            saveFileDialog1.Filter = "テキストファイル(*.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            var path = saveFileDialog1.FileName;
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(Path.GetDirectoryName(path))) {
                return;
            }
            save(path);
        }

        private void toolStripMenuItem_file_pdf_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Menu[Edit] events
        private void toolStripMenuItem_edit_undo_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_redo_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_esc_Click(object sender, EventArgs e) {
        }

        private void toolStripMenuItem_edit_cut_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_copy_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_paste_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_delete_Click(object sender, EventArgs e) {
        }
        #endregion

        #region Menu[Display] events
        private void toolStripMenuItem_disp_moveToLocalOrigin_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_moveToGlobalOrigin_Click(object sender, EventArgs e) {
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;
        }

        private void toolStripMenuItem_disp_100_Click(object sender, EventArgs e) {
            mDispScale = 1;
        }

        private void toolStripMenuItem_disp_zoomIn_Click(object sender, EventArgs e) {
            if (mDispScale < 16) {
                mDispScale++;
            }
        }

        private void toolStripMenuItem_disp_zoomOut_Click(object sender, EventArgs e) {
            if (1 < mDispScale) {
                mDispScale--;
            }
        }

        private void toolStripMenuItem_disp_setGridPitch_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_localGrid_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_globalGrid_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Menu[Snap] events
        private void toolStripMenuItem_snap_grid_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_snap_vert_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_snap_line_Click(object sender, EventArgs e) {

        }
        #endregion

        #region Menu[Mode] events
        private void toolStripMenuItem_mode_select_Click(object sender, EventArgs e) {
        }

        private void toolStripMenuItem_mode_moveLocalOrigin_Click(object sender, EventArgs e) {
        }

        private void toolStripMenuItem_mode_polyline_Click(object sender, EventArgs e) {
        }

        private void toolStripMenuItem_mode_polygonFill_Click(object sender, EventArgs e) {
        }

        private void toolStripMenuItem_mode_polygonHole_Click(object sender, EventArgs e) {
        }
        #endregion

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
