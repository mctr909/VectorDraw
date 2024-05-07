using System;
using System.Drawing;
using System.IO;

namespace Geometry {
	public struct Rectangle : IGeometry {
		public static float LastThickness = 10;

		public PointF Pa;
		public PointF Pb;
		public float Thickness;

		PointF[] mPoly;

		public EPost HasGrippedPost(Point cursor) {
			if (Util.HasGrippedPost(Pa, cursor)) {
				return EPost.A;
			}
			if (Util.HasGrippedPost(Pb, cursor)) {
				return EPost.B;
			}
			return EPost.NONE;
		}

		public bool IsSelected(Point cursor) {
			return Util.HasInnerPoint(mPoly[0], mPoly[1], mPoly[2], cursor)
				|| Util.HasInnerPoint(mPoly[2], mPoly[3], mPoly[0], cursor);
		}

		public void Write(StreamWriter sw) {
			sw.WriteLine("RECT {0} {1} {2} {3}",
				Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
				Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
				Thickness.ToString("g3")
			);
		}

		public void Read(string[] cols) {
			Pa.X = float.Parse(cols[1]);
			Pa.Y = float.Parse(cols[2]);
			Pb.X = float.Parse(cols[3]);
			Pb.Y = float.Parse(cols[4]);
			Thickness = float.Parse(cols[5]);
			Calc();
		}

		public void Move(PointF delta) {
			Pa.X += delta.X;
			Pa.Y += delta.Y;
			Pb.X += delta.X;
			Pb.Y += delta.Y;
			Calc();
		}

		public void Calc() {
			var sx = Pb.X - Pa.X;
			var sy = Pb.Y - Pa.Y;
			var th = Math.Atan2(sy, sx) - Math.PI / 2;
			var c = 0.5f * Thickness * (float)Math.Cos(th);
			var s = 0.5f * Thickness * (float)Math.Sin(th);
			mPoly = new PointF[4];
			mPoly[0].X = Pa.X + c;
			mPoly[0].Y = Pa.Y + s;
			mPoly[1].X = Pa.X - c;
			mPoly[1].Y = Pa.Y - s;
			mPoly[2].X = Pb.X - c;
			mPoly[2].Y = Pb.Y - s;
			mPoly[3].X = Pb.X + c;
			mPoly[3].Y = Pb.Y + s;
		}

		public void Draw(Graphics g, bool highlight = false) {
			if (highlight) {
				g.FillPolygon(Util.BSelect, mPoly);
				Util.DrawPost(g, Pa);
				Util.DrawPost(g, Pb);
			} else {
				g.FillPolygon(Util.BSolid, mPoly);
			}
		}
	}
}
