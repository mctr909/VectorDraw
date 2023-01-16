using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VectorDraw {
    public partial class Form1 : Form {
        enum EMODE {
            SELECT,
            ORIGIN,
            POLYLINE,
            POLYGON_FILL,
            POLYGON_HOLE
        }
        enum ESTATE {
            NONE,
            BEGIN,
            DRAG,
            NEXT
        }

        List<PointF> mPosList = new List<PointF>();
        List<PointF[]> mLineList = new List<PointF[]>();

        EMODE mMode = EMODE.SELECT;
        ESTATE mSTATE = ESTATE.NONE;
        Point mOffset = new Point();

        bool mSizeChange = false;
        Point mCursorPos = new Point();
        Point mMouseDownPos = new Point();
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

        }

        private void toolStripMenuItem_file_overwrite_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_file_save_Click(object sender, EventArgs e) {

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
            switch (mMode) {
            case EMODE.SELECT:
                break;
            case EMODE.ORIGIN:
                break;
            case EMODE.POLYLINE:
            case EMODE.POLYGON_FILL:
            case EMODE.POLYGON_HOLE:
                mPosList.Clear();
                mSTATE = ESTATE.BEGIN;
                break;
            }
        }

        private void toolStripMenuItem_edit_cut_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_copy_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_paste_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_edit_delete_Click(object sender, EventArgs e) {
            var posCur = pictureBox1.PointToClient(Cursor.Position);
            switch (mMode) {
            case EMODE.SELECT:
                break;
            case EMODE.ORIGIN:
                break;
            case EMODE.POLYLINE:
            case EMODE.POLYGON_FILL:
            case EMODE.POLYGON_HOLE:
                for (int i = 0; i < mLineList.Count; i++) {
                    if (pointOnLine(mLineList[i], posCur)) {
                        mLineList.RemoveAt(i);
                        break;
                    }
                }
                break;
            }
        }
        #endregion

        #region Menu[Display] events
        private void toolStripMenuItem_disp_moveToLocalOrigin_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_moveToGlobalOrigin_Click(object sender, EventArgs e) {
            hScrollBar1.Value = 0;
            vScrollBar1.Value = 0;
        }

        private void toolStripMenuItem_disp_localGrid_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_globalGrid_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_100_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_zoomIn_Click(object sender, EventArgs e) {

        }

        private void toolStripMenuItem_disp_zoomOut_Click(object sender, EventArgs e) {

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
            mMode = EMODE.SELECT;
            mSTATE = ESTATE.NONE;
        }

        private void toolStripMenuItem_mode_moveLocalOrigin_Click(object sender, EventArgs e) {
            mMode = EMODE.ORIGIN;
            mSTATE = ESTATE.NONE;
        }

        private void toolStripMenuItem_mode_polyline_Click(object sender, EventArgs e) {
            mMode = EMODE.POLYLINE;
            mSTATE = ESTATE.BEGIN;
        }

        private void toolStripMenuItem_mode_polygonFill_Click(object sender, EventArgs e) {
            mMode = EMODE.POLYGON_FILL;
            mSTATE = ESTATE.BEGIN;
        }

        private void toolStripMenuItem_mode_polygonHole_Click(object sender, EventArgs e) {
            mMode = EMODE.POLYGON_HOLE;
            mSTATE = ESTATE.BEGIN;
        }
        #endregion

        #region PictureBox events
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
            mMouseDownPos = pictureBox1.PointToClient(Cursor.Position);
            mMouseDownPos.X -= mOffset.X - hScrollBar1.Value;
            mMouseDownPos.Y -= mOffset.Y - vScrollBar1.Value;
            switch (mMode) {
            case EMODE.SELECT:
                if (ESTATE.NONE == mSTATE) {
                    mSTATE = ESTATE.DRAG;
                }
                break;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
            switch (mMode) {
            case EMODE.SELECT:
                if (ESTATE.DRAG == mSTATE) {
                    mSTATE = ESTATE.NONE;
                }
                break;
            case EMODE.ORIGIN:
                break;
            case EMODE.POLYLINE:
            case EMODE.POLYGON_FILL:
            case EMODE.POLYGON_HOLE:
                switch (mSTATE) {
                case ESTATE.BEGIN:
                    mPosList = new List<PointF>();
                    mPosList.Add(new Point(mCursorPos.X, mCursorPos.Y));
                    mSTATE = ESTATE.NEXT;
                    break;
                case ESTATE.NEXT:
                    if (e.Button == MouseButtons.Left) {
                        mPosList.Add(new Point(mCursorPos.X, mCursorPos.Y));
                    } else {
                        if (3 <= mPosList.Count) {
                            mPosList.Add(mPosList[0]);
                            mLineList.Add(mPosList.ToArray());
                            mPosList.Clear();
                            mSTATE = ESTATE.BEGIN;
                        }
                    }
                    break;
                }
                break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            mCursorPos = pictureBox1.PointToClient(Cursor.Position);
            mCursorPos.X -= mOffset.X - hScrollBar1.Value;
            mCursorPos.Y -= mOffset.Y - vScrollBar1.Value;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e) {
            if (mSizeChange) {
                sizeChange();
            }

            mG.Clear(Color.Transparent);

            mG.DrawLine(Pens.Red, new Point(0, mOffset.Y), new Point(mBmp.Width, mOffset.Y));
            mG.DrawLine(Pens.Red, new Point(mOffset.X, 0), new Point(mOffset.X, mBmp.Height));

            drawEditingLine();
            drawLine();

            if (EMODE.SELECT == mMode && ESTATE.DRAG == mSTATE) {

            }

            pictureBox1.Image = pictureBox1.Image;
        }

        void drawLine() {
            var posCur = pictureBox1.PointToClient(Cursor.Position);
            foreach (var line in mLineList) {
                var lineColor = pointOnLine(line, posCur) ? Pens.LightBlue : Pens.Gray;
                var posA = line[0];
                posA.X += mOffset.X - hScrollBar1.Value;
                posA.Y += mOffset.Y - vScrollBar1.Value;
                for (int i = 1; i < line.Length; i++) {
                    var posB = line[i];
                    posB.X += mOffset.X - hScrollBar1.Value;
                    posB.Y += mOffset.Y - vScrollBar1.Value;
                    mG.DrawLine(lineColor, posA, posB);
                    posA = posB;
                }
            }
        }

        void drawEditingLine() {
            if (1 == mPosList.Count) {
                var posA = mPosList[0];
                posA.X += mOffset.X - hScrollBar1.Value;
                posA.Y += mOffset.Y - vScrollBar1.Value;
                var posB = mCursorPos;
                posB.X += mOffset.X - hScrollBar1.Value;
                posB.Y += mOffset.Y - vScrollBar1.Value;
                mG.DrawLine(Pens.SkyBlue, posA, posB);
            } else if (2 <= mPosList.Count) {
                var posA = mPosList[0];
                posA.X += mOffset.X - hScrollBar1.Value;
                posA.Y += mOffset.Y - vScrollBar1.Value;
                PointF posB;
                for (int i = 1; i < mPosList.Count; i++) {
                    posB = mPosList[i];
                    posB.X += mOffset.X - hScrollBar1.Value;
                    posB.Y += mOffset.Y - vScrollBar1.Value;
                    mG.DrawLine(Pens.SkyBlue, posA, posB);
                    posA = posB;
                }
                posB = mCursorPos;
                posB.X += mOffset.X - hScrollBar1.Value;
                posB.Y += mOffset.Y - vScrollBar1.Value;
                mG.DrawLine(Pens.SkyBlue, posA, posB);
            }
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

            mBmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            mG = Graphics.FromImage(mBmp);
            pictureBox1.Image = mBmp;
            mOffset.X = mBmp.Width / 2;
            mOffset.Y = mBmp.Height / 2;
        }

        bool pointOnLine(PointF[] line, PointF p) {
            var posA = line[0];
            posA.X += mOffset.X - hScrollBar1.Value;
            posA.Y += mOffset.Y - vScrollBar1.Value;
            PointF posB;
            for (int i = 1; i < line.Length; i++) {
                posB = line[i];
                posB.X += mOffset.X - hScrollBar1.Value;
                posB.Y += mOffset.Y - vScrollBar1.Value;
                if (pointOnLine(posA, posB, p)) {
                    return true;
                }
                posA = posB;
            }
            return false;
        }

        bool pointOnLine(PointF a, PointF b, PointF p) {
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
            return (pqx * pqx + pqy * pqy) < 16;
        }
    }
}
