using System;
using System.Drawing;
using System.IO;

namespace Geometry {
	public struct Arrow : IGeometry {
		public static float LastLength = 15;
		public static float LastWidth = 5;
		public static float LastThickness = 1;

		public PointF Pa;
		public PointF Pb;
		public float Length;
		public float Width;
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
			return Util.HasOnLinePost(Pa, Pb, cursor);
		}

		public void Write(StreamWriter sw) {
			sw.WriteLine("ARROW {0} {1} {2} {3}",
				Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
				Pb.X.ToString("g3"), Pb.Y.ToString("g3"),
				Length.ToString("g3"), Width.ToString("g3"),
				Thickness.ToString("g3")
			);
		}

		public void Read(string[] cols) {
			Pa.X = float.Parse(cols[1]);
			Pa.Y = float.Parse(cols[2]);
			Pb.X = float.Parse(cols[3]);
			Pb.Y = float.Parse(cols[4]);
			Length = float.Parse(cols[5]);
			Width = float.Parse(cols[6]);
			Thickness = float.Parse(cols[7]);
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
			var wc = Width * (float)Math.Cos(th);
			var ws = Width * (float)Math.Sin(th);
			var ph = th - Math.PI / 2;
			var lc = Length * (float)Math.Cos(ph);
			var ls = Length * (float)Math.Sin(ph);
			var tc = 0.5f * Thickness * (float)Math.Cos(th);
			var ts = 0.5f * Thickness * (float)Math.Sin(th);
			if (0 == Width || 0 == Length) {
				mPoly = new PointF[4];
				mPoly[0].X = Pb.X + tc;
				mPoly[0].Y = Pb.Y + ts;
				mPoly[1].X = Pb.X - tc;
				mPoly[1].Y = Pb.Y - ts;
				mPoly[2].X = Pa.X - tc;
				mPoly[2].Y = Pa.Y - ts;
				mPoly[3].X = Pa.X + tc;
				mPoly[3].Y = Pa.Y + ts;
			} else if (Thickness < 1) {
				Thickness = 0;
				mPoly = new PointF[3];
				mPoly[0].X = Pb.X;
				mPoly[0].Y = Pb.Y;
				mPoly[1].X = Pb.X + lc + wc;
				mPoly[1].Y = Pb.Y + ls + ws;
				mPoly[2].X = Pb.X + lc - wc;
				mPoly[2].Y = Pb.Y + ls - ws;
			} else {
				mPoly = new PointF[7];
				mPoly[0].X = Pb.X;
				mPoly[0].Y = Pb.Y;
				mPoly[1].X = Pb.X + lc + wc;
				mPoly[1].Y = Pb.Y + ls + ws;
				mPoly[2].X = Pb.X + lc + tc;
				mPoly[2].Y = Pb.Y + ls + ts;
				mPoly[3].X = Pa.X + tc;
				mPoly[3].Y = Pa.Y + ts;
				mPoly[4].X = Pa.X - tc;
				mPoly[4].Y = Pa.Y - ts;
				mPoly[5].X = Pb.X + lc - tc;
				mPoly[5].Y = Pb.Y + ls - ts;
				mPoly[6].X = Pb.X + lc - wc;
				mPoly[6].Y = Pb.Y + ls - ws;
			}
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
