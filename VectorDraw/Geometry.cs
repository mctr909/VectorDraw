using System;
using System.Drawing;
using System.IO;

namespace VectorDraw {
    static class Geo {
        public const int POST_RADIUS = 3;
        public static readonly Pen PGray = new Pen(Color.FromArgb(63, 63, 63), 1);
        public static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
        public static readonly Pen PPost = new Pen(Color.FromArgb(191, 0, 0), 1);
        public static readonly Pen PSelect = new Pen(Color.FromArgb(0, 191, 191), 1);
        public static bool HasGrippedPost(PointF post, Point cursor) {
            var opx = post.X - cursor.X;
            var opy = post.Y - cursor.Y;
            return Math.Sqrt(opx * opx + opy * opy) <= POST_RADIUS;
        }
        public static void DrawPost(Graphics g, PointF pos) {
            const int diameter = POST_RADIUS * 2;
            g.DrawArc(PPost,
                pos.X - POST_RADIUS, pos.Y - POST_RADIUS,
                diameter, diameter,
                0, 360
            );
        }
        public static void DrawArc(Graphics g, Pen color, PointF pos, double radius, double sweep = 360, double begin = 0) {
            g.DrawArc(color,
                pos.X - (float)radius, pos.Y - (float)radius,
                (float)radius * 2, (float)radius * 2,
                (float)begin, (float)sweep
            );
        }
    }
    
    public enum EPOST { NONE, A, B, O }

    interface IGeo {
        EPOST GetGippedPost(Point p);
        void Write(StreamWriter sw);
        void Load(string[] cols);
        void Draw(Graphics g, bool highlight = false);
    }

    struct Line : IGeo {
        public PointF Pa;
        public PointF Pb;
        public EPOST GetGippedPost(Point cursor) {
            if (Geo.HasGrippedPost(Pa, cursor)) {
                return EPOST.A;
            }
            if (Geo.HasGrippedPost(Pb, cursor)) {
                return EPOST.B;
            }
            return EPOST.NONE;
        }
        public void Write(StreamWriter sw) {
            sw.WriteLine("LINE {0} {1} {2} {3}",
                Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
                Pb.X.ToString("g3"), Pb.Y.ToString("g3")
            );
        }
        public void Load(string[] cols) {
            Pa.X = float.Parse(cols[1]);
            Pa.Y = float.Parse(cols[2]);
            Pb.X = float.Parse(cols[3]);
            Pb.Y = float.Parse(cols[4]);
        }
        public void Draw(Graphics g, bool highlight = false) {
            if (highlight) {
                g.DrawLine(Geo.PSelect, Pa, Pb);
                Geo.DrawPost(g, Pa);
                Geo.DrawPost(g, Pb);
            } else {
                g.DrawLine(Geo.PLine, Pa, Pb);
            }
        }
    }

    struct Arc : IGeo {
        public PointF Po;
        public double Radius;
        public double Begin;
        public double Sweep;
        public EPOST GetGippedPost(Point cursor) {
            var th = Math.PI * Begin / 180;
            var p = new PointF(
                (float)(Po.X + Radius * Math.Cos(th)),
                (float)(Po.Y + Radius * Math.Sin(th))
            );
            if (Geo.HasGrippedPost(p, cursor)) {
                return EPOST.A;
            }
            th += Math.PI * Sweep / 180;
            p.X = (float)(Po.X + Radius * Math.Cos(th));
            p.Y = (float)(Po.Y + Radius * Math.Sin(th));
            if (Geo.HasGrippedPost(p, cursor)) {
                return EPOST.B;
            }
            return EPOST.NONE;
        }
        public void Write(StreamWriter sw) {
            sw.WriteLine("ARC {0} {1} {2} {3} {4}",
                Po.X.ToString("g3"), Po.Y.ToString("g3"),
                Radius.ToString("g3"),
                Begin.ToString("g3"), Sweep.ToString("g3")
            );
        }
        public void Load(string[] cols) {
            Po.X = float.Parse(cols[1]);
            Po.Y = float.Parse(cols[2]);
            Radius = float.Parse(cols[3]);
            Begin = float.Parse(cols[4]);
            Sweep = float.Parse(cols[5]);
        }
        public void Draw(Graphics g, bool highlight = false) {
            if (highlight) {
                Geo.DrawArc(g, Geo.PSelect, Po, Radius, (float)Sweep, (float)Begin);
                var th = Math.PI * Begin / 180;
                var p = new PointF(
                    (float)(Po.X + Radius * Math.Cos(th)),
                    (float)(Po.Y + Radius * Math.Sin(th))
                );
                Geo.DrawPost(g, p);
                th += Math.PI * Sweep / 180;
                p.X = (float)(Po.X + Radius * Math.Cos(th));
                p.Y = (float)(Po.Y + Radius * Math.Sin(th));
                Geo.DrawPost(g, p);
            } else {
                Geo.DrawArc(g, Geo.PLine, Po, Radius, (float)Sweep, (float)Begin);
            }
        }
    }

    struct Bow : IGeo {
        public PointF Pa;
        public PointF Pb;
        public double Radius {
            get { return mArc.Radius; }
            set { mArc.Radius = value; }
        }

        Arc mArc;

        public EPOST GetGippedPost(Point cursor) {
            if (Geo.HasGrippedPost(Pa, cursor)) {
                return EPOST.A;
            }
            if (Geo.HasGrippedPost(Pb, cursor)) {
                return EPOST.B;
            }
            return EPOST.NONE;
        }
        public void Write(StreamWriter sw) {
            sw.WriteLine("BOW {0} {1} {2} {3} {4}",
                Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
                Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
                Radius.ToString("g3")
            );
        }
        public void Load(string[] cols) {
            Pa.X = float.Parse(cols[1]);
            Pa.Y = float.Parse(cols[2]);
            Pb.X = float.Parse(cols[3]);
            Pb.Y = float.Parse(cols[4]);
            Radius = float.Parse(cols[5]);
        }
        public void Draw(Graphics g, bool highlight = false) {
            if (highlight) {
                Geo.DrawArc(g, Geo.PSelect, mArc.Po, Math.Abs(mArc.Radius),
                    (float)mArc.Sweep, (float)mArc.Begin);
                Geo.DrawPost(g, Pa);
                Geo.DrawPost(g, Pb);
            } else {
                Geo.DrawArc(g, Geo.PLine, mArc.Po, Math.Abs(mArc.Radius),
                    (float)mArc.Sweep, (float)mArc.Begin);
            }
        }
        public PointF Calc(double distance = 0) {
            var abx = Pb.X - Pa.X;
            var aby = Pb.Y - Pa.Y;
            var ab_len = Math.Sqrt(abx * abx + aby * aby);
            var ab_arg = Math.Atan2(aby, abx);
            var bao_arg = Math.Acos(ab_len / mArc.Radius * 0.5);
            var ox = Pa.X + mArc.Radius * Math.Cos(bao_arg + ab_arg);
            var oy = Pa.Y + mArc.Radius * Math.Sin(bao_arg + ab_arg);
            var oax = Pa.X - ox;
            var oay = Pa.Y - oy;
            var obx = Pb.X - ox;
            var oby = Pb.Y - oy;
            var oa_deg = Math.Atan2(oay, oax) * 180 / Math.PI;
            var ob_deg = Math.Atan2(oby, obx) * 180 / Math.PI;
            mArc.Begin = oa_deg;
            mArc.Sweep = ob_deg - oa_deg;
            mArc.Po.X = (float)ox;
            mArc.Po.Y = (float)oy;
            return mArc.Po;
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

        public EPOST GetGippedPost(Point cursor) {
            if (Geo.HasGrippedPost(Pa, cursor)) {
                return EPOST.A;
            }
            if (Geo.HasGrippedPost(Po, cursor)) {
                return EPOST.O;
            }
            if (Geo.HasGrippedPost(Pb, cursor)) {
                return EPOST.B;
            }
            return EPOST.NONE;
        }
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
                g.DrawLine(Geo.PGray, mL1.Pb, Po);
                g.DrawLine(Geo.PGray, Po, mL2.Pa);
                Geo.DrawArc(g, Geo.PGray, mArc.Po, mArc.Radius);
                g.DrawLine(Geo.PSelect, mL1.Pa, mL1.Pb);
                g.DrawLine(Geo.PSelect, mL2.Pa, mL2.Pb);
                Geo.DrawArc(g, Geo.PSelect, mArc.Po,
                    mArc.Radius, (float)mArc.Sweep, (float)mArc.Begin);
                Geo.DrawPost(g, mArc.Po);
                Geo.DrawPost(g, Po);
                Geo.DrawPost(g, Pa);
                Geo.DrawPost(g, Pb);
            } else {
                g.DrawLine(Geo.PLine, mL1.Pa, mL1.Pb);
                g.DrawLine(Geo.PLine, mL2.Pa, mL2.Pb);
                Geo.DrawArc(g, Geo.PLine, mArc.Po,
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

            mL1.Pa = Pa;
            mL1.Pb.X = (float)(Po.X + oapx);
            mL1.Pb.Y = (float)(Po.Y + oapy);
            mL2.Pa.X = (float)(Po.X + obpx);
            mL2.Pa.Y = (float)(Po.Y + obpy);
            mL2.Pb = Pb;

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
            mArc.Po.X = Po.X + (float)px;
            mArc.Po.Y = Po.Y + (float)py;
            return mArc.Po;
        }
    }
}
