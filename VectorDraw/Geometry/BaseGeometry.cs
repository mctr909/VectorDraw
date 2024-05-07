using System.Drawing;
using System.Xml;

namespace Geometry {
	public abstract class BaseGeometry {
		protected const int DRAW_POST_RADIUS = 3;
		protected const int GRIP_POST_RADIUS = 5;

		static readonly Pen PPost = new Pen(Color.FromArgb(255, 255, 0), 1);
		static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
		static readonly Pen PLineHighlight = new Pen(Color.FromArgb(0, 255, 255), 1);
		static readonly Pen PHoleHighlight = new Pen(Color.FromArgb(255, 0, 0), 1);

		static readonly Brush BSolid = new Pen(Color.FromArgb(63, 63, 63), 1).Brush;
		static readonly Brush BSolidHighlight = new Pen(Color.FromArgb(0, 95, 95), 1).Brush;
		static readonly Brush BPostHighlight = new Pen(Color.FromArgb(0, 255, 255), 1).Brush;

		public vec2 Pos;
		public BaseGeometry Parent;

		public BaseGeometry() { }
		public BaseGeometry(XmlReader xml, BaseGeometry parent) {
			Parent = parent;
			while (xml.MoveToNextAttribute()) {
				ReadAttr(xml);
			}
			ReadInner(xml);
		}

		protected static bool HasGrippedPost(vec2 post, vec2 cursor) {
			var op = post - cursor;
			return op.Norm <= GRIP_POST_RADIUS;
		}
		protected static bool HasOnLinePoint(vec2 a, vec2 b, vec2 p) {
			var ab = b - a;
			var abl2 = ab * ab;
			if (0 == abl2) {
				return false;
			}
			var ap = p - a;
			var t = ab * ap / abl2;
			if (t < 0) {
				t = 0;
			}
			if (1 < t) {
				t = 1;
			}
			var pq = a + ab * t - p;
			return pq.Norm <= DRAW_POST_RADIUS;
		}
		protected static void DrawLine(Graphics g, vec2 a, vec2 b, bool highlight = false) {
			g.DrawLine(highlight ? PLineHighlight : PLine, a.Point, b.Point);
		}
		protected static void DrawLines(Graphics g, PointF[] points, bool highlight = false) {
			g.DrawLines(highlight ? PLineHighlight : PLine, points);
		}
		protected static void DrawPost(Graphics g, vec2 pos, bool highlight = false) {
			if (highlight) {
				g.FillEllipse(BPostHighlight,
					(float)(pos.X - GRIP_POST_RADIUS),
					(float)(pos.Y - GRIP_POST_RADIUS),
					GRIP_POST_RADIUS * 2, GRIP_POST_RADIUS * 2
				);
			}
			else {
				g.DrawArc(PPost,
					(float)(pos.X - DRAW_POST_RADIUS),
					(float)(pos.Y - DRAW_POST_RADIUS),
					DRAW_POST_RADIUS * 2, DRAW_POST_RADIUS * 2,
					0, 360
				);
			}
		}
		protected static void DrawArc(Graphics g, bool highlight, vec2 center, double radius, double sweep = 360, double begin = 0) {
			g.DrawArc(highlight ? PLineHighlight : PLine,
				(float)(center.X - radius),
				(float)(center.Y - radius),
				(float)(radius * 2), (float)(radius * 2),
				(float)begin, (float)sweep
			);
		}
		protected static void DrawPolygon(Graphics g, PointF[] points, bool highlight = false) {
			g.DrawPolygon(highlight ? PLineHighlight : PLine, points);
		}
		protected static void DrawHole(Graphics g, PointF[] points, bool highlight = false) {
			g.DrawPolygon(highlight ? PHoleHighlight : PLine, points);
		}
		protected static void FillPolygon(Graphics g, PointF[] points, bool highlight = false) {
			g.FillPolygon(highlight ? BSolidHighlight : BSolid, points);
		}

		public abstract BaseGeometry GetPost(vec2 cursor);
		public virtual void SetGripPost(BaseGeometry post) { }
		public abstract bool IsSelected(vec2 cursor);
		public abstract void Write(XmlWriter xml);
		public abstract void ReadAttr(XmlReader xml);
		public virtual void ReadInner(XmlReader xml) { }
		public abstract void Move(vec2 delta);
		public abstract void Draw(Graphics g);
		public abstract void DrawHighlight(Graphics g);
	}
}
