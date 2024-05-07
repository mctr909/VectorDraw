using System;
using System.Drawing;

namespace Geometry {
	public class Drawer : IDisposable {
		public static readonly Pen PGray = new Pen(Color.FromArgb(63, 63, 63), 1);
		public static readonly Pen PLine = new Pen(Color.FromArgb(191, 191, 191), 1);
		public static readonly Pen PPost = new Pen(Color.FromArgb(191, 0, 0), 1);
		public static readonly Pen PSelect = new Pen(Color.FromArgb(0, 191, 191), 1);

		public static readonly Brush BSolid = PLine.Brush;
		public static readonly Brush BSelect = PSelect.Brush;

		private Graphics G;

		public Drawer(Bitmap bmp) {
			G = Graphics.FromImage(bmp);
		}

		public void Dispose() {
			G.Dispose();
		}

		public void Clear(Color color) {
			G.Clear(color);
		}

		public void DrawPost(Vec2 pos) {
			var diameter = Vec2.PostRadius * 2;
			G.DrawArc(PPost,
				(float)pos.X - Vec2.PostRadius, (float)pos.Y - Vec2.PostRadius,
				diameter, diameter,
				0, 360
			);
		}

		public void DrawLine(Pen color, Vec2 a, Vec2 b) {
			G.DrawLine(color, (float)a.X, (float)a.Y, (float)b.X, (float)b.Y);
		}

		public void DrawArc(Pen color, Vec2 pos, double radius, double sweep = 360, double begin = 0) {
			G.DrawArc(color,
				(float)(pos.X - radius), (float)(pos.Y - radius),
				(float)radius * 2, (float)radius * 2,
				(float)begin, (float)sweep
			);
		}
	}
}
