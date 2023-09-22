using System;
using System.Drawing;
using System.IO;

namespace VectorDraw {
    static class Geo {
        public const int KNOB_R = 2;
        public const int KNOB_D = 4;
        public static readonly Pen PGray = new Pen(Color.FromArgb(63, 63, 63), 1);
        public static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
        public static readonly Pen PKnob = new Pen(Color.FromArgb(191, 0, 0), 1);
        public static readonly Pen PSelect = new Pen(Color.FromArgb(0, 191, 191), 1);
        public static void DrawKnob(Graphics g, PointF pos) {
            g.DrawArc(PKnob, pos.X - KNOB_R, pos.Y - KNOB_R, KNOB_D, KNOB_D, 0, 360);
        }
        public static void DrawArc(Graphics g, Pen color, PointF pos, double radius, double sweep = 360, double begin = 0) {
            g.DrawArc(color,
                pos.X - (float)radius, pos.Y - (float)radius,
                (float)radius * 2, (float)radius * 2,
                (float)begin, (float)sweep
            );
        }
    }

    interface IGeo {
        void Write(StreamWriter sw);
        void Load(string[] cols);
        void Draw(Graphics g, bool highlight = false);
    }

    struct Line : IGeo {
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
                g.DrawLine(Geo.PSelect, P1, P2);
                Geo.DrawKnob(g, P1);
                Geo.DrawKnob(g, P2);
            } else {
                g.DrawLine(Geo.PLine, P1, P2);
            }
        }
    }

    struct Arc : IGeo {
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
            Sweep = float.Parse(cols[5]);
        }
        public void Draw(Graphics g, bool highlight = false) {
            if (highlight) {
                Geo.DrawArc(g, Geo.PSelect, Center, Radius, (float)Sweep, (float)Begin);
            } else {
                Geo.DrawArc(g, Geo.PLine, Center, Radius, (float)Sweep, (float)Begin);
            }
        }
    }

    struct Bow : IGeo {
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
                Geo.DrawArc(g, Geo.PSelect, mArc.Center, Math.Abs(mArc.Radius),
                    (float)mArc.Sweep, (float)mArc.Begin);
            } else {
                Geo.DrawArc(g, Geo.PLine, mArc.Center, Math.Abs(mArc.Radius),
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

    struct Corner : IGeo {
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
                g.DrawLine(Geo.PGray, mL1.P2, Po);
                g.DrawLine(Geo.PGray, Po, mL2.P1);
                Geo.DrawArc(g, Geo.PGray, mArc.Center, mArc.Radius);
                g.DrawLine(Geo.PSelect, mL1.P1, mL1.P2);
                g.DrawLine(Geo.PSelect, mL2.P1, mL2.P2);
                Geo.DrawArc(g, Geo.PSelect, mArc.Center,
                    mArc.Radius, (float)mArc.Sweep, (float)mArc.Begin);
                Geo.DrawKnob(g, mArc.Center);
                Geo.DrawKnob(g, Po);
                Geo.DrawKnob(g, Pa);
                Geo.DrawKnob(g, Pb);
            } else {
                g.DrawLine(Geo.PLine, mL1.P1, mL1.P2);
                g.DrawLine(Geo.PLine, mL2.P1, mL2.P2);
                Geo.DrawArc(g, Geo.PLine, mArc.Center,
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
            if (t < 0) {
                t = 0;
            }
            if (1 < t) {
                t = 1;
            }
            if (u < 0) {
                u = 0;
            }
            if (1 < u) {
                u = 1;
            }
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

}
