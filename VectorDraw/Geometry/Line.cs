using System.Drawing;

namespace Geometry {
	public class Line : IGeometry {
		public Vec2 A;
		public Vec2 B;

		public EPost HasGrippedPost(Point cursor) {
			if (Vec2.HasGrippedPost(cursor, A)) {
				return EPost.A;
			}
			if (Vec2.HasGrippedPost(cursor, B)) {
				return EPost.B;
			}
			return EPost.NONE;
		}

		public bool IsSelected(Point cursor) {
			return Vec2.HasOnLine(cursor, A, B);
		}

		public void Draw(Drawer g, bool highlight = false) {
			if (highlight) {
				g.DrawLine(Drawer.PSelect, A, B);
				g.DrawPost(A);
				g.DrawPost(B);
			} else {
				g.DrawLine(Drawer.PLine, A, B);
			}
		}
	}
}
