using System;
using System.Drawing;

namespace Geometry {
	internal static class Util {
		public const int POST_RADIUS = 3;
		public static readonly Pen PGray = new Pen(Color.FromArgb(63, 63, 63), 1);
		public static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
		public static readonly Pen PPost = new Pen(Color.FromArgb(191, 0, 0), 1);
		public static readonly Pen PSelect = new Pen(Color.FromArgb(0, 191, 191), 1);

		public static readonly Brush BSolid = PLine.Brush;
		public static readonly Brush BSelect = PSelect.Brush;

		public static bool HasGrippedPost(PointF post, Point cursor) {
			var opx = post.X - cursor.X;
			var opy = post.Y - cursor.Y;
			return Math.Sqrt(opx * opx + opy * opy) <= POST_RADIUS;
		}

		public static bool HasOnLinePost(PointF a, PointF b, PointF p) {
			var abx = b.X - a.X;
			var aby = b.Y - a.Y;
			var abl2 = abx * abx + aby * aby;
			if (0 == abl2) {
				return false;
			}
			var apx = p.X - a.X;
			var apy = p.Y - a.Y;
			var t = (abx * apx + aby * apy) / abl2;
			if (t < 0) {
				t = 0;
			}
			if (1 < t) {
				t = 1;
			}
			var pqx = (a.X + abx * t) - p.X;
			var pqy = (a.Y + aby * t) - p.Y;
			return Math.Sqrt(pqx * pqx + pqy * pqy) <= POST_RADIUS;
		}

		public static bool HasInnerPoint(PointF a, PointF o, PointF b, PointF p) {
			var aoX = o.X - a.X;
			var aoY = o.Y - a.Y;
			var opX = p.X - o.X;
			var opY = p.Y - o.Y;
			var na = aoX * opY - aoY * opX;
			var obX = b.X - o.X;
			var obY = b.Y - o.Y;
			var bpX = p.X - b.X;
			var bpY = p.Y - b.Y;
			var no = obX * bpY - obY * bpX;
			var baX = a.X - b.X;
			var baY = a.Y - b.Y;
			var apX = p.X - a.X;
			var apY = p.Y - a.Y;
			var nb = baX * apY - baY * apX;
			return (0 < na && 0 < no && 0 < nb) || (na < 0 && no < 0 && nb < 0);
		}

		public static void DrawPost(Graphics g, PointF pos) {
			const int diameter = POST_RADIUS * 2;
			g.DrawArc(PPost,
				pos.X - POST_RADIUS, pos.Y - POST_RADIUS,
				diameter, diameter,
				0, 360
			);
		}

		public static void DrawArc(Graphics g, Pen color, PointF pos, double radius, double sweep = 360, double begin = 0) {
			g.DrawArc(color,
				pos.X - (float)radius, pos.Y - (float)radius,
				(float)radius * 2, (float)radius * 2,
				(float)begin, (float)sweep
			);
		}
	}
}
