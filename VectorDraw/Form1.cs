using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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

        const int KNOB_R = 2;
        const int KNOB_D = 4;
        static readonly Pen PGray = new Pen(Color.FromArgb(63, 63, 63), 1);
        static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
        static readonly Pen PKnob = new Pen(Color.FromArgb(191, 0, 0), 1);
        static readonly Pen PSelect = new Pen(Color.FromArgb(0, 191, 191), 1);

        Bitmap mBmp;
        Graphics mG;
        bool mSizeChange = false;
        Point mScroll = new Point();

        static void DrawKnob(Graphics g, PointF pos) {
            g.DrawArc(PKnob, pos.X - KNOB_R, pos.Y - KNOB_R, KNOB_D, KNOB_D, 0, 360);
        }
        static void DrawArc(Graphics g, Pen color, PointF pos, double radius, double sweep = 360, double begin = 0) {
            g.DrawArc(color,
                pos.X - (float)radius, pos.Y - (float)radius,
                (float)radius * 2, (float)radius * 2,
                (float)begin, (float)sweep
            );
        }

        interface IRecord {
            void Write(StreamWriter sw);
            void Load(string[] cols);
            void Draw(Graphics g, bool highlight = false);
        }

        struct Line : IRecord {
            public PointF P1;
            public PointF P2;
            public void Write(StreamWriter sw) {
                sw.WriteLine("LINE {0} {1} {2} {3}",
                    P1.X.ToString("g3"), P1.Y.ToString("g3"),
                    P2.X.ToString("g3"), P2.Y.ToString("g3")
                );
            }
            public void Load(string[] cols) {
                P1.X = float.Parse(cols[1]);
                P1.Y = float.Parse(cols[2]);
                P2.X = float.Parse(cols[3]);
                P2.Y = float.Parse(cols[4]);
            }
            public void Draw(Graphics g, bool highlight = false) {
                if (highlight) {
                    g.DrawLine(PSelect, P1, P2);
                    DrawKnob(g, P1);
                    DrawKnob(g, P2);
                } else {
                    g.DrawLine(PLine, P1, P2);
                }
            }
        }

        struct Arc : IRecord {
            public PointF Center;
            public double Radius;
            public double Begin;
            public double Sweep;
            public void Write(StreamWriter sw) {
                sw.WriteLine("ARC {0} {1} {2} {3} {4}",
                    Center.X.ToString("g3"), Center.Y.ToString("g3"),
                    Radius.ToString("g3"),
                    Begin.ToString("g3"), Sweep.ToString("g3")
                );
            }
            public void Load(string[] cols) {
                Center.X = float.Parse(cols[1]);
                Center.Y = float.Parse(cols[2]);
                Radius = float.Parse(cols[3]);
                Begin = float.Parse(cols[4]);
                Sweep = float.Parse(cols[4]);
            }
            public void Draw(Graphics g, bool highlight = false) {
                if (highlight) {
                    DrawArc(g, PSelect, Center, Radius, (float)Sweep, (float)Begin);
                } else {
                    DrawArc(g, PLine, Center, Radius, (float)Sweep, (float)Begin);
                }
            }
        }

        struct Bow : IRecord {
            public PointF P1;
            public PointF P2;
            public double Radius {
                get { return mArc.Radius; }
                set { mArc.Radius = value; }
            }

            Arc mArc;

            public void Write(StreamWriter sw) {
                sw.WriteLine("BOW {0} {1} {2} {3} {4}",
                    P1.X.ToString("g3"), P1.Y.ToString("g3"),
                    P2.X.ToString("g3"), P2.Y.ToString("g3"),
                    Radius.ToString("g3")
                );
            }
            public void Load(string[] cols) {
                P1.X = float.Parse(cols[1]);
                P1.Y = float.Parse(cols[2]);
                P2.X = float.Parse(cols[3]);
                P2.Y = float.Parse(cols[4]);
                Radius = float.Parse(cols[5]);
            }
            public void Draw(Graphics g, bool highlight = false) {
                if (highlight) {
                    DrawArc(g, PSelect, mArc.Center, Math.Abs(mArc.Radius),
                        (float)mArc.Sweep, (float)mArc.Begin);
                } else {
                    DrawArc(g, PLine, mArc.Center, Math.Abs(mArc.Radius),
                        (float)mArc.Sweep, (float)mArc.Begin);
                }
            }
            public PointF Calc(double distance = 0) {
                var abx = P2.X - P1.X;
                var aby = P2.Y - P1.Y;
                var ab_len = Math.Sqrt(abx * abx + aby * aby);
                var ab_arg = Math.Atan2(aby, abx);
                var bao_arg = Math.Acos(ab_len / mArc.Radius * 0.5);
                var ox = P1.X + mArc.Radius * Math.Cos(bao_arg + ab_arg);
                var oy = P1.Y + mArc.Radius * Math.Sin(bao_arg + ab_arg);
                var oax = P1.X - ox;
                var oay = P1.Y - oy;
                var obx = P2.X - ox;
                var oby = P2.Y - oy;
                var oa_deg = Math.Atan2(oay, oax) * 180 / Math.PI;
                var ob_deg = Math.Atan2(oby, obx) * 180 / Math.PI;
                mArc.Begin = oa_deg;
                mArc.Sweep = ob_deg - oa_deg;
                mArc.Center.X = (float)ox;
                mArc.Center.Y = (float)oy;
                return mArc.Center;
            }
        }

        struct Corner : IRecord {
            public PointF Pa;
            public PointF Po;
            public PointF Pb;
            public double Radius {
                get { return mArc.Radius; }
                set { mArc.Radius = value; }
            }

            Line mL1;
            Line mL2;
            Arc mArc;

            public void Write(StreamWriter sw) {
                sw.WriteLine("CORNER {0} {1} {2} {3} {4} {5} {6}",
                    Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
                    Po.X.ToString("g3"), Po.Y.ToString("g3"),
                    Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
                    Radius.ToString("g3")
                );
            }
            public void Load(string[] cols) {
                Pa.X = float.Parse(cols[1]);
                Pa.Y = float.Parse(cols[2]);
                Po.X = float.Parse(cols[3]);
                Po.Y = float.Parse(cols[4]);
                Pb.X = float.Parse(cols[5]);
                Pb.Y = float.Parse(cols[6]);
                Radius = float.Parse(cols[7]);
                Calc();
            }
            public void Draw(Graphics g, bool highlight = false) {
                if (highlight) {
                    g.DrawLine(PGray, mL1.P2, Po);
                    g.DrawLine(PGray, Po, mL2.P1);
                    DrawArc(g, PGray, mArc.Center, mArc.Radius);
                    g.DrawLine(PSelect, mL1.P1, mL1.P2);
                    g.DrawLine(PSelect, mL2.P1, mL2.P2);
                    DrawArc(g, PSelect, mArc.Center,
                        mArc.Radius, (float)mArc.Sweep, (float)mArc.Begin);
                    DrawKnob(g, mArc.Center);
                    DrawKnob(g, Po);
                    DrawKnob(g, Pa);
                    DrawKnob(g, Pb);
                } else {
                    g.DrawLine(PLine, mL1.P1, mL1.P2);
                    g.DrawLine(PLine, mL2.P1, mL2.P2);
                    DrawArc(g, PLine, mArc.Center,
                        mArc.Radius, (float)mArc.Sweep, (float)mArc.Begin);
                }
            }
            public PointF Calc(double distance = 0) {
                double oax = Pa.X - Po.X;
                double oay = Pa.Y - Po.Y;
                double obx = Pb.X - Po.X;
                double oby = Pb.Y - Po.Y;
                double oa_len = Math.Sqrt(oax * oax + oay * oay);
                double ob_len = Math.Sqrt(obx * obx + oby * oby);
                double px = oax / oa_len + obx / ob_len;
                double py = oay / oa_len + oby / ob_len;
                double p_len = Math.Sqrt(px * px + py * py);

                if (distance == 0) {
                    px /= p_len;
                    py /= p_len;
                    var d = Radius / Math.Sin(Math.Abs(Math.Atan2(py, px) - Math.Atan2(oay, oax)));
                    px *= d;
                    py *= d;
                } else {
                    px *= distance / p_len;
                    py *= distance / p_len;
                }

                double t = (oax * px + oay * py) / oa_len / oa_len;
                double u = (obx * px + oby * py) / ob_len / ob_len;
                double oapx = t * oax;
                double oapy = t * oay;
                double obpx = u * obx;
                double obpy = u * oby;

                mL1.P1 = Pa;
                mL1.P2.X = (float)(Po.X + oapx);
                mL1.P2.Y = (float)(Po.Y + oapy);
                mL2.P1.X = (float)(Po.X + obpx);
                mL2.P1.Y = (float)(Po.Y + obpy);
                mL2.P2 = Pb;

                var qx = oapx - px;
                var qy = oapy - py;
                var q_arg = Math.Atan2(qy, qx);
                if (q_arg < 0) {
                    q_arg += Math.PI * 2;
                }
                var rx = obpx - px;
                var ry = obpy - py;
                var r_arg = Math.Atan2(ry, rx);
                if (r_arg < 0) {
                    r_arg += Math.PI * 2;
                }

                if (q_arg < r_arg) {
                    mArc.Begin = q_arg * 180 / Math.PI;
                    mArc.Sweep = (r_arg - q_arg) * 180 / Math.PI;
                } else {
                    mArc.Begin = r_arg * 180 / Math.PI;
                    mArc.Sweep = (q_arg - r_arg) * 180 / Math.PI;
                }

                mArc.Radius = Math.Sqrt(qx * qx + qy * qy);
                mArc.Center.X = Po.X + (float)px;
                mArc.Center.Y = Po.Y + (float)py;
                return mArc.Center;
            }
        }

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

        private void tsmMode_Click(object sender, EventArgs e) {
            tsmModeSelect.Checked = false;
            tsmModeMoveLocalOrigin.Checked = false;
            tsmModePolyline.Checked = false;
            tsmModePolygonFill.Checked = false;
            tsmModePolygonHole.Checked = false;

            var item = (ToolStripMenuItem)sender;
            item.Checked = true;

            if (item == tsmModeSelect) {
                //mMode = MODE.SELECT;
                //mMouseState = MOUSE_STATE.BEGIN;
                return;
            }
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

        #region PictureBox events
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            var mousePos = pictureBox1.PointToClient(Cursor.Position);
            //tslPos.Text = string.Format("{0}mm, {1}mm", mCursor.X.ToString("0.##"), mCursor.Y.ToString("0.##"));
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e) {
            if (mSizeChange) {
                sizeChange();
                mSizeChange = false;
            }
            var c = new Bow();
            c.P1.X = 400;
            c.P1.Y = 200;
            var th = Math.PI * 10 / 180;
            c.P2.X = c.P1.X + 300 * (float)Math.Cos(th);
            c.P2.Y = c.P1.Y - 300 * (float)Math.Sin(th);

            c.Radius = 160;
            c.Calc();
            c.Draw(mG);

            c.Radius = -160;
            c.Calc();
            c.Draw(mG);
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
