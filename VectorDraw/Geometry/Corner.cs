using System;
using System.Drawing;
using System.IO;

namespace Geometry {
	public struct Corner : IGeometry {
		public static float LastRadius = 60;

		public PointF Pa;
		public PointF Po;
		public PointF Pb;

		public double Radius {
			get { return Arc.Radius; }
			set { Arc.Radius = value; }
		}

		PointF Pa2;
		PointF Pb1;
		Arc Arc;

		public EPost HasGrippedPost(Point cursor) {
			if (Util.HasGrippedPost(Pa, cursor)) {
				return EPost.A;
			}
			if (Util.HasGrippedPost(Po, cursor)) {
				return EPost.O;
			}
			if (Util.HasGrippedPost(Pb, cursor)) {
				return EPost.B;
			}
			return EPost.NONE;
		}

		public bool IsSelected(Point cursor) {
			if (Util.HasOnLinePost(Pa, Pa2, cursor)) {
				return true;
			}
			if (Util.HasOnLinePost(Pb1, Pb, cursor)) {
				return true;
			}
			var opx = cursor.X - Arc.Po.X;
			var opy = cursor.Y - Arc.Po.Y;
			var opr = Math.Sqrt(opx * opx + opy * opy);
			if (Util.POST_RADIUS < Math.Abs(opr - Radius)) {
				return false;
			}
			var op_arg = Math.Atan2(opy, opx) * 180 / Math.PI - Arc.Begin;
			if (op_arg < 0) {
				op_arg += 360;
			} else {
				op_arg -= 360 * ((int)op_arg / 360);
			}
			if (op_arg < 0 || Arc.Sweep < op_arg) {
				return false;
			}
			return true;
		}

		public void Write(StreamWriter sw) {
			sw.WriteLine("CORNER {0} {1} {2} {3} {4} {5} {6}",
				Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
				Po.X.ToString("g3"), Po.Y.ToString("g3"),
				Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
				Radius.ToString("g3")
			);
		}

		public void Read(string[] cols) {
			Pa.X = float.Parse(cols[1]);
			Pa.Y = float.Parse(cols[2]);
			Po.X = float.Parse(cols[3]);
			Po.Y = float.Parse(cols[4]);
			Pb.X = float.Parse(cols[5]);
			Pb.Y = float.Parse(cols[6]);
			Radius = float.Parse(cols[7]);
			Calc();
		}

		public void Move(PointF delta) {
			Pa.X += delta.X;
			Pa.Y += delta.Y;
			Po.X += delta.X;
			Po.Y += delta.Y;
			Pb.X += delta.X;
			Pb.Y += delta.Y;
			Pa2.X += delta.X;
			Pa2.Y += delta.Y;
			Pb1.X += delta.X;
			Pb1.Y += delta.Y;
			Arc.Po.X += delta.X;
			Arc.Po.Y += delta.Y;
		}

		public void Draw(Graphics g, bool highlight = false) {
			if (highlight) {
				g.DrawLine(Util.PGray, Pa2, Po);
				g.DrawLine(Util.PGray, Po, Pb1);
				Util.DrawArc(g, Util.PGray, Arc.Po, Arc.Radius);
				g.DrawLine(Util.PSelect, Pa, Pa2);
				g.DrawLine(Util.PSelect, Pb1, Pb);
				Util.DrawArc(g, Util.PSelect, Arc.Po,
					Arc.Radius, (float)Arc.Sweep, (float)Arc.Begin);
				Util.DrawPost(g, Arc.Po);
				Util.DrawPost(g, Po);
				Util.DrawPost(g, Pa);
				Util.DrawPost(g, Pb);
			} else {
				g.DrawLine(Util.PLine, Pa, Pa2);
				g.DrawLine(Util.PLine, Pb1, Pb);
				Util.DrawArc(g, Util.PLine, Arc.Po,
					Arc.Radius, (float)Arc.Sweep, (float)Arc.Begin);
			}
		}

		public PointF Calc(double distance = 0) {
			var oax = Pa.X - Po.X;
			var oay = Pa.Y - Po.Y;
			var obx = Pb.X - Po.X;
			var oby = Pb.Y - Po.Y;
			var oa_len = Math.Sqrt(oax * oax + oay * oay);
			var ob_len = Math.Sqrt(obx * obx + oby * oby);
			var px = oax / oa_len + obx / ob_len;
			var py = oay / oa_len + oby / ob_len;
			var p_len = Math.Sqrt(px * px + py * py);

			if (distance == 0) {
				px /= p_len;
				py /= p_len;
				var d = Math.Min(1000, Radius / Math.Sin(Math.Abs(Math.Atan2(py, px) - Math.Atan2(oay, oax))));
				px *= d;
				py *= d;
			} else {
				px *= distance / p_len;
				py *= distance / p_len;
			}

			var t = (oax * px + oay * py) / oa_len / oa_len;
			var u = (obx * px + oby * py) / ob_len / ob_len;
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
			var oapx = t * oax;
			var oapy = t * oay;
			var obpx = u * obx;
			var obpy = u * oby;

			Pa2.X = (float)(Po.X + oapx);
			Pa2.Y = (float)(Po.Y + oapy);
			Pb1.X = (float)(Po.X + obpx);
			Pb1.Y = (float)(Po.Y + obpy);

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
				Arc.Begin = q_arg * 180 / Math.PI;
				Arc.Sweep = (r_arg - q_arg) * 180 / Math.PI;
			} else {
				Arc.Begin = r_arg * 180 / Math.PI;
				Arc.Sweep = (q_arg - r_arg) * 180 / Math.PI;
			}

			Arc.Radius = Math.Sqrt(qx * qx + qy * qy);
			Arc.Po.X = Po.X + (float)px;
			Arc.Po.Y = Po.Y + (float)py;
			return Arc.Po;
		}
	}
}
