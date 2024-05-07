using System.Drawing;
using System.IO;

namespace Geometry {
	public struct Line : IGeometry {
		public PointF Pa;
		public PointF Pb;

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
			sw.WriteLine("LINE {0} {1} {2} {3}",
				Pa.X.ToString("g3"), Pa.Y.ToString("g3"),
				Pb.X.ToString("g3"), Pb.Y.ToString("g3")
			);
		}

		public void Read(string[] cols) {
			Pa.X = float.Parse(cols[1]);
			Pa.Y = float.Parse(cols[2]);
			Pb.X = float.Parse(cols[3]);
			Pb.Y = float.Parse(cols[4]);
		}

		public void Move(PointF delta) {
			Pa.X += delta.X;
			Pa.Y += delta.Y;
			Pb.X += delta.X;
			Pb.Y += delta.Y;
		}

		public void Draw(Graphics g, bool highlight = false) {
			if (highlight) {
				g.DrawLine(Util.PSelect, Pa, Pb);
				Util.DrawPost(g, Pa);
				Util.DrawPost(g, Pb);
			} else {
				g.DrawLine(Util.PLine, Pa, Pb);
			}
		}
	}
}
