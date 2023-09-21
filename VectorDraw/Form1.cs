using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VectorDraw {
    public partial class Form1 : Form {
        Bitmap mBmp;
        Graphics mG;
        bool mSizeChange = false;
        Point mScroll = new Point();

        interface Record {
            void Write(StreamWriter sw);
            void Load(string[] cols);
        }

        struct Line : Record {
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
        }

        struct Corner : Record {
            public PointF Pa;
            public PointF Po;
            public PointF Pb;
            public double Distance;

            Line mL1;
            Line mL2;
            Arc mArc;

            public void Write(StreamWriter sw) {
                sw.WriteLine("CORNER {0} {1} {2} {3} {4} {5} {6}",
                    Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
                    Po.X.ToString("g3"), Po.Y.ToString("g3"),
                    Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
                    Distance.ToString("g3")
                );
            }
            public void Load(string[] cols) {
                Pa.X = float.Parse(cols[1]);
                Pa.Y = float.Parse(cols[2]);
                Po.X = float.Parse(cols[3]);
                Po.Y = float.Parse(cols[4]);
                Pb.X = float.Parse(cols[5]);
                Pb.Y = float.Parse(cols[6]);
                Distance = float.Parse(cols[7]);
                Calc();
            }
            public PointF Calc(bool distance = true) {
                double oax = Pa.X - Po.X;
                double oay = Pa.Y - Po.Y;
                double obx = Pb.X - Po.X;
                double oby = Pb.Y - Po.Y;
                double oa_len = Math.Sqrt(oax * oax + oay * oay);
                double ob_len = Math.Sqrt(obx * obx + oby * oby);
                double px = oax / oa_len + obx / ob_len;
                double py = oay / oa_len + oby / ob_len;
                double p_len = Math.Sqrt(px * px + py * py);

                if (distance) {
                    px *= Distance / p_len;
                    py *= Distance / p_len;
                } else {
                    px /= p_len;
                    py /= p_len;
                    return new PointF((float)px, (float)py);
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
            public void Draw(Graphics g, bool dispKnob = false) {
                g.DrawLine(Pens.White, mL1.P1, mL1.P2);
                g.DrawLine(Pens.White, mL2.P1, mL2.P2);
                if (dispKnob) {
                    g.DrawLine(Pens.Gray, mL1.P2, Po);
                    g.DrawLine(Pens.Gray, Po, mL2.P1);
                    g.DrawArc(Pens.Red, Po.X - 2, Po.Y - 2, 4, 4, 0, 360);
                    g.DrawArc(Pens.Red, Pa.X - 2, Pa.Y - 2, 4, 4, 0, 360);
                    g.DrawArc(Pens.Red, Pb.X - 2, Pb.Y - 2, 4, 4, 0, 360);
                    g.DrawArc(Pens.Cyan, mArc.Center.X - 2, mArc.Center.Y - 2, 4, 4, 0, 360);
                }
                g.DrawArc(Pens.White,
                    mArc.Center.X - (float)mArc.Radius, mArc.Center.Y - (float)mArc.Radius,
                    (float)mArc.Radius * 2, (float)mArc.Radius * 2,
                    (float)mArc.Begin, (float)mArc.Sweep
                );
            }
        }

        struct Arc : Record {
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
        }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            sizeChange();
            KeyPreview = true;
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
