using System;
using System.Drawing;
using System.IO;

namespace Geometry {
	public struct Arc : IGeometry {
		public PointF Po;
		public double Radius;
		public double Begin;
		public double Sweep;

		public EPost HasGrippedPost(Point cursor) {
			var th = Math.PI * Begin / 180;
			var p = new PointF(
				(float)(Po.X + Radius * Math.Cos(th)),
				(float)(Po.Y + Radius * Math.Sin(th))
			);
			if (Util.HasGrippedPost(p, cursor)) {
				return EPost.A;
			}
			th += Math.PI * Sweep / 180;
			p.X = (float)(Po.X + Radius * Math.Cos(th));
			p.Y = (float)(Po.Y + Radius * Math.Sin(th));
			if (Util.HasGrippedPost(p, cursor)) {
				return EPost.B;
			}
			return EPost.NONE;
		}

		public bool IsSelected(Point cursor) {
			var opx = cursor.X - Po.X;
			var opy = cursor.Y - Po.Y;
			var opr = Math.Sqrt(opx * opx + opy * opy);
			if (Util.POST_RADIUS < Math.Abs(opr - Radius)) {
				return false;
			}
			var op_arg = Math.Atan2(opy, opx) * 180 / Math.PI - Begin;
			if (op_arg < 0) {
				op_arg += 360;
			} else {
				op_arg -= 360 * ((int)op_arg / 360);
			}
			if (op_arg < 0 || Sweep < op_arg) {
				return false;
			}
			return true;
		}

		public void Write(StreamWriter sw) {
			sw.WriteLine("ARC {0} {1} {2} {3} {4}",
				Po.X.ToString("g3"), Po.Y.ToString("g3"),
				Radius.ToString("g3"),
				Begin.ToString("g3"), Sweep.ToString("g3")
			);
		}

		public void Read(string[] cols) {
			Po.X = float.Parse(cols[1]);
			Po.Y = float.Parse(cols[2]);
			Radius = float.Parse(cols[3]);
			Begin = float.Parse(cols[4]);
			Sweep = float.Parse(cols[5]);
		}

		public void Move(PointF delta) {
			Po.X += delta.X;
			Po.Y += delta.Y;
		}

		public void Draw(Graphics g, bool highlight = false) {
			if (highlight) {
				Util.DrawArc(g, Util.PSelect, Po, Radius, (float)Sweep, (float)Begin);
				var th = Math.PI * Begin / 180;
				var p = new PointF(
					(float)(Po.X + Radius * Math.Cos(th)),
					(float)(Po.Y + Radius * Math.Sin(th))
				);
				Util.DrawPost(g, p);
				th += Math.PI * Sweep / 180;
				p.X = (float)(Po.X + Radius * Math.Cos(th));
				p.Y = (float)(Po.Y + Radius * Math.Sin(th));
				Util.DrawPost(g, p);
			} else {
				Util.DrawArc(g, Util.PLine, Po, Radius, (float)Sweep, (float)Begin);
			}
		}
	}
}
