using System.Drawing;
using System.IO;

namespace Geometry {
	interface IGeometry {
		EPost HasGrippedPost(Point cursor);
		bool IsSelected(Point cursor);
		void Write(StreamWriter sw);
		void Read(string[] cols);
		void Move(PointF delta);
		void Draw(Graphics g, bool highlight = false);
	}
}
