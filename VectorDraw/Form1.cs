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
        public enum EPOS {
            POINT,
            ARC
        }
        public enum EOBJ {
            LINE,
            FILL,
            HOLE
        }

        public struct POINT {
            public EPOS Type;
            public float X;
            public float Y;
            public float Radius;
            public float Begin;
            public float Elapse;

            public POINT(double x = 0.0, double y = 0.0) {
                Type = EPOS.POINT;
                X = (float)x;
                Y = (float)y;
                Radius = 0.0f;
                Begin = 0.0f;
                Elapse = 0.0f;
            }
        }

        public class OBJECT {
            public EOBJ Type = EOBJ.LINE;
            public List<POINT> Points = new List<POINT>();
        }

        List<POINT> mPosList = new List<POINT>();
        List<OBJECT> mObjList = new List<OBJECT>();

        EMODE mMode = EMODE.SELECT;
        ESTATE mSTATE = ESTATE.NONE;
        POINT mOffset = new POINT();

        int mDispScale = 1;
        bool mSizeChange = false;
        POINT mCursorPos = new POINT();
        POINT mMouseDownPos = new POINT();
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
                for (int i = 0; i < mObjList.Count; i++) {
                    for (int j = 0; j < mObjList[i].Points.Count; j++) {
                        if (pointOnLine(mObjList[i].Points, posCur)) {
                            mObjList.RemoveAt(i);
                            return;
                        }
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
            var pos = pictureBox1.PointToClient(Cursor.Position); 
            mMouseDownPos.X = pos.X - mOffset.X + hScrollBar1.Value;
            mMouseDownPos.Y = pos.Y - mOffset.Y + vScrollBar1.Value;
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
                    mPosList = new List<POINT>() {
                        new POINT(mCursorPos.X, mCursorPos.Y)
                    };
                    mSTATE = ESTATE.NEXT;
                    break;
                case ESTATE.NEXT:
                    if (e.Button == MouseButtons.Left) {
                        mPosList.Add(new POINT(mCursorPos.X, mCursorPos.Y));
                    } else {
                        if (3 <= mPosList.Count) {
                            mPosList.Add(mPosList[0]);
                            var p = new OBJECT();
                            p.Points.AddRange(mPosList);
                            mObjList.Add(p);
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
            var pos = pictureBox1.PointToClient(Cursor.Position);
            mCursorPos.X = pos.X - mOffset.X + hScrollBar1.Value;
            mCursorPos.Y = pos.Y - mOffset.Y + vScrollBar1.Value;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e) {
            if (mSizeChange) {
                sizeChange();
            }

            mG.Clear(Color.Transparent);

            mG.DrawLine(Pens.Red, new PointF(0, mOffset.Y), new PointF(mBmp.Width, mOffset.Y));
            mG.DrawLine(Pens.Red, new PointF(mOffset.X, 0), new PointF(mOffset.X, mBmp.Height));

            drawEditingLine();
            drawLine();

            pictureBox1.Image = pictureBox1.Image;
        }

        void drawLine() {
            var posA = new PointF();
            var posB = new PointF();
            var posCur = pictureBox1.PointToClient(Cursor.Position);
            foreach (var obj in mObjList) {
                var lineColor = pointOnLine(obj.Points, posCur) ? Pens.SkyBlue : Pens.Gray;
                posA.X = obj.Points[0].X + mOffset.X - hScrollBar1.Value;
                posA.Y = obj.Points[0].Y + mOffset.Y - vScrollBar1.Value;
                for (int i = 1; i < obj.Points.Count; i++) {
                    posB.X = obj.Points[i].X + mOffset.X - hScrollBar1.Value;
                    posB.Y = obj.Points[i].Y + mOffset.Y - vScrollBar1.Value;
                    mG.DrawLine(lineColor, posA, posB);
                    posA = posB;
                }
            }
        }

        void drawEditingLine() {
            var posA = new PointF();
            var posB = new PointF();
            if (1 == mPosList.Count) {
                posA.X = mPosList[0].X + mOffset.X - hScrollBar1.Value;
                posA.Y = mPosList[0].Y + mOffset.Y - vScrollBar1.Value;
                posB.X = mCursorPos.X + mOffset.X - hScrollBar1.Value;
                posB.Y = mCursorPos.Y + mOffset.Y - vScrollBar1.Value;
            } else if (2 <= mPosList.Count) {
                posA.X = mPosList[0].X + mOffset.X - hScrollBar1.Value;
                posA.Y = mPosList[0].Y + mOffset.Y - vScrollBar1.Value;
                for (int i = 1; i < mPosList.Count; i++) {
                    posB.X = mPosList[i].X + mOffset.X - hScrollBar1.Value;
                    posB.Y = mPosList[i].Y + mOffset.Y - vScrollBar1.Value;
                    mG.DrawLine(Pens.SkyBlue, posA, posB);
                    posA = posB;
                }
                posB.X = mCursorPos.X + mOffset.X - hScrollBar1.Value;
                posB.Y = mCursorPos.Y + mOffset.Y - vScrollBar1.Value;
            } else {
                return;
            }
            mG.DrawLine(Pens.SkyBlue, posA, posB);
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

        bool pointOnLine(List<POINT> line, PointF p) {
            var posA = new POINT();
            var posB = new POINT();
            posA.X = line[0].X + mOffset.X - hScrollBar1.Value;
            posA.Y = line[0].Y + mOffset.Y - vScrollBar1.Value;
            for (int i = 1; i < line.Count; i++) {
                posB.X = line[i].X + mOffset.X - hScrollBar1.Value;
                posB.Y = line[i].Y + mOffset.Y - vScrollBar1.Value;
                if (pointOnLine(posA, posB, p)) {
                    return true;
                }
                posA = posB;
            }
            return false;
        }

        bool pointOnLine(POINT a, POINT b, PointF p, int limitDist = 5) {
            var abx = b.X - a.X;
            var aby = b.Y - a.Y;
            var apx = p.X - a.X;
            var apy = p.Y - a.Y;
            var abL2 = abx * abx + aby * aby;
            POINT q;
            if (0 == abL2) {
                q = a;
            } else {
                var r = (apx * abx + apy * aby) / abL2;
                if (r <= 0.0) {
                    q = a;
                } else if (1.0 <= r) {
                    q = b;
                } else {
                    q = new POINT(abx * r + a.X, aby * r + a.Y);
                }
            }
            var pqx = q.X - p.X;
            var pqy = q.Y - p.Y;
            var pqL2 = pqx * pqx + pqy * pqy;
            return pqL2 < limitDist * limitDist;
        }
    }
}
