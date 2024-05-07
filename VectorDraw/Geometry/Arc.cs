using System;
using System.Drawing;

namespace Geometry {
	public class Arc : IGeometry {
		public static float LastRadius = 80;

		public Vec2 A;
		public Vec2 B;
		public Vec2 O;
		public double Radius = LastRadius;

		private Vec2 At;
		private Vec2 Bu;
		private Vec2 G;
		private double Begin;
		private double Sweep;

		public EPost HasGrippedPost(Point cursor) {
			if (Vec2.HasGrippedPost(cursor, A)) {
				return EPost.A;
			}
			if (Vec2.HasGrippedPost(cursor, B)) {
				return EPost.B;
			}
			if (Vec2.HasGrippedPost(cursor, O)) {
				return EPost.O;
			}
			return EPost.NONE;
		}

		public bool IsSelected(Point cursor) {
			if (Vec2.HasOnLine(cursor, A, At)) {
				return true;
			}
			if (Vec2.HasOnLine(cursor, Bu, B)) {
				return true;
			}
			var gp = cursor - G;
			if (Math.Abs(gp.Norm - Radius) > Vec2.PostRadius) {
				return false;
			}
			var sweep = gp.Angle * 180 / Math.PI - Begin;
			var rotateCount = (int)(sweep / 360);
			if (sweep < 0) {
				rotateCount--;
			}
			sweep -= 360 * rotateCount;
			return sweep <= Sweep;
		}

		public void Draw(Drawer g, bool highlight = false) {
			if (highlight) {
				g.DrawLine(Drawer.PGray, At, O);
				g.DrawLine(Drawer.PGray, O, Bu);
				g.DrawLine(Drawer.PSelect, A, At);
				g.DrawLine(Drawer.PSelect, Bu, B);
				g.DrawArc(Drawer.PSelect, G, Radius, Sweep, Begin);
				g.DrawPost(O);
				g.DrawPost(A);
				g.DrawPost(B);
			} else {
				g.DrawLine(Drawer.PLine, A, At);
				g.DrawLine(Drawer.PLine, Bu, B);
				g.DrawArc(Drawer.PLine, G, Radius, Sweep, Begin);
			}
		}

		public void Calc() {
			var a = A - O;
			var b = B - O;
			var aLen = a.Norm;
			var bLen = b.Norm;

			var g = a / aLen + b / bLen;
			var s = g.Norm * Math.Sin(g.Angle - a.Angle);
			g *= Radius / Math.Max(1e-9, Math.Abs(s));
			G = O + g;

			var t = (a & g) / aLen / aLen;
			var u = (b & g) / bLen / bLen;
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

			var aT = a * t;
			var bU = b * u;
			At = O + aT;
			Bu = O + bU;

			var ga = aT - g;
			var gb = bU - g;
			var gaAngle = ga.Angle;
			if (gaAngle < 0) {
				gaAngle += Math.PI * 2;
			}
			var gbAngle = gb.Angle;
			if (gbAngle < 0) {
				gbAngle += Math.PI * 2;
			}

			Radius = ga.Norm;
			if (gaAngle < gbAngle) {
				Begin = gaAngle * 180 / Math.PI;
				Sweep = (gbAngle - gaAngle) * 180 / Math.PI;
			} else {
				Begin = gbAngle * 180 / Math.PI;
				Sweep = (gaAngle - gbAngle) * 180 / Math.PI;
			}
		}
	}
}
