using System;
using System.Drawing;

namespace Geometry {
	public struct vec2 {
		public double X;
		public double Y;

		public double Norm { get { return Math.Sqrt(X * X + Y * Y); } }
		public double Angle { get { return Math.Atan2(Y, X); } }
		public PointF Point { get { return new PointF((float)X, (float)Y); } }

		public vec2(double x = 0.0, double y = 0.0) {
			X = x;
			Y = y;
		}
		public vec2(PointF p) {
			X = p.X;
			Y = p.Y;
		}
		public vec2(vec2 p) {
			X = p.X;
			Y = p.Y;
		}

		public static vec2 FromPhaser(double radius, double radian, vec2 offset = default) {
			return new vec2(
				radius * Math.Cos(radian) + offset.X,
				radius * Math.Sin(radian) + offset.Y
			);
		}

		/// <summary>
		/// 加法(a+b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator +(vec2 a, vec2 b) {
			return new vec2(a.X + b.X, a.Y + b.Y);
		}
		/// <summary>
		/// 加法(a+b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator +(vec2 a, PointF b) {
			return new vec2(a.X + b.X, a.Y + b.Y);
		}
		/// <summary>
		/// 加法(a+b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator +(PointF a, vec2 b) {
			return new vec2(a.X + b.X, a.Y + b.Y);
		}

		/// <summary>
		/// 減法(a-b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator -(vec2 a, vec2 b) {
			return new vec2(a.X - b.X, a.Y - b.Y);
		}
		/// <summary>
		/// 減法(a-b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator -(vec2 a, PointF b) {
			return new vec2(a.X - b.X, a.Y - b.Y);
		}
		/// <summary>
		/// 減法(a-b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static vec2 operator -(PointF a, vec2 b) {
			return new vec2(a.X - b.X, a.Y - b.Y);
		}

		/// <summary>
		/// スカラー乗法(v・k)
		/// </summary>
		/// <param name="v"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static vec2 operator *(vec2 v, double k) {
			return new vec2(v.X * k, v.Y * k);
		}
		/// <summary>
		/// スカラー乗法(k・v)
		/// </summary>
		/// <param name="k"></param>
		/// <param name="v"></param>
		/// <returns></returns>
		public static vec2 operator *(double k, vec2 v) {
			return new vec2(v.X * k, v.Y * k);
		}
		/// <summary>
		/// スカラー乗法(v/k)
		/// </summary>
		/// <param name="v"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static vec2 operator /(vec2 v, double k) {
			return new vec2(v.X / k, v.Y / k);
		}

		/// <summary>
		/// 内積(a・b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator *(vec2 a, vec2 b) {
			return a.X * b.X + a.Y * b.Y;
		}
		/// <summary>
		/// 内積(a・b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator *(vec2 a, PointF b) {
			return a.X * b.X + a.Y * b.Y;
		}
		/// <summary>
		/// 内積(a・b)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator *(PointF a, vec2 b) {
			return a.X * b.X + a.Y * b.Y;
		}

		/// <summary>
		/// 外積(aΛb)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator ^(vec2 a, vec2 b) {
			return a.X * b.Y - a.Y * b.X;
		}
		/// <summary>
		/// 外積(aΛb)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator ^(vec2 a, PointF b) {
			return a.X * b.Y - a.Y * b.X;
		}
		/// <summary>
		/// 外積(aΛb)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static double operator ^(PointF a, vec2 b) {
			return a.X * b.Y - a.Y * b.X;
		}
	}
}
