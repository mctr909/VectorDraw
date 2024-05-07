using System;
using System.Drawing;

namespace Geometry {
	public struct Vec2 {
		public double X;
		public double Y;

		public static readonly Vec2 Zero = new Vec2 { X = 0, Y = 0 };
		public static readonly Vec2 MinValue = new Vec2 { X = double.MinValue, Y = double.MinValue };
		public static int PostRadius = 3;
		private const int LineWidth = 5;

		public double Norm => Math.Sqrt(X * X + Y * Y);
		public double Angle => Math.Atan2(Y, X);
		public string String => $"{X:g3} {Y:g3}";

		public static Vec2 Parse(string x, string y) {
			return new Vec2 {
				X = double.Parse(x),
				Y = double.Parse(y)
			};
		}

		public static Vec2 FromPhaser(double radius, double theta) {
			return new Vec2 {
				X = radius * Math.Cos(theta),
				Y = radius * Math.Sin(theta)
			};
		}
		
		public static bool HasGrippedPost(PointF cursor, Vec2 post) {
			return (post - cursor).Norm <= PostRadius;
		}

		public static bool HasOnLine(PointF cursor, Vec2 a, Vec2 b) {
			var ab = b - a;
			var abl2 = ab & ab;
			if (0 == abl2) {
				return false;
			}
			var ap = cursor - a;
			var t = (ab & ap) / abl2;
			if (t < 0) {
				t = 0;
			}
			if (1 < t) {
				t = 1;
			}
			var pq = ab * t + a - cursor;
			return pq.Norm <= LineWidth;
		}

		public static Vec2 operator +(Vec2 a, Vec2 b) {
			return new Vec2 { X = a.X + b.X, Y = a.Y + b.Y };
		}
		public static Vec2 operator +(Vec2 a, PointF b) {
			return new Vec2 { X = a.X + b.X, Y = a.Y + b.Y };
		}
		public static Vec2 operator +(PointF a, Vec2 b) {
			return new Vec2 { X = a.X + b.X, Y = a.Y + b.Y };
		}
		public static Vec2 operator -(Vec2 a, Vec2 b) {
			return new Vec2 { X = a.X - b.X, Y = a.Y - b.Y };
		}
		public static Vec2 operator -(Vec2 a, PointF b) {
			return new Vec2 { X = a.X - b.X, Y = a.Y - b.Y };
		}
		public static Vec2 operator -(PointF a, Vec2 b) {
			return new Vec2 { X = a.X - b.X, Y = a.Y - b.Y };
		}
		public static Vec2 operator *(Vec2 v, double k) {
			return new Vec2 { X = v.X * k, Y = v.Y * k };
		}
		public static Vec2 operator *(double k, Vec2 v) {
			return new Vec2 { X = v.X * k, Y = v.Y * k };
		}
		public static Vec2 operator /(Vec2 v, double k) {
			return new Vec2 { X = v.X / k, Y = v.Y / k };
		}
		public static double operator *(Vec2 a, Vec2 b) {
			return a.X * b.Y - a.Y * b.X;
		}
		public static double operator &(Vec2 a, Vec2 b) {
			return a.X * b.X + a.Y * b.Y;
		}
	}
}
