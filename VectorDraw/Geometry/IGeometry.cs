using System.Drawing;

namespace Geometry {
	interface IGeometry {
		EPost HasGrippedPost(Point cursor);
		bool IsSelected(Point cursor);
		void Draw(Drawer g, bool highlight = false);
	}
}
