using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace Geometry {
	public class Corner : BaseGeometry {
		public const string TagName = "c";

		public static double LastRadius = 1.0;

		public Post A;
		public Post B;

		public double Radius {
			get { return Arc.Radius; }
			set { Arc.Radius = value; }
		}
		public vec2 C { get { return Arc.Pos; } }

		vec2 P;
		vec2 Q;
		Arc Arc = new Arc() {
			Radius = LastRadius
		};

		public Corner() { }
		public Corner(XmlReader xml, BaseGeometry parent = null) : base(xml, parent) { }

		public override BaseGeometry GetPost(vec2 cursor) {
			return null;
		}

		public override bool IsSelected(vec2 cursor) {
			if (HasOnLinePoint(A.Pos, P, cursor)) {
				return true;
			}
			if (HasOnLinePoint(Q, B.Pos, cursor)) {
				return true;
			}
			var oc = cursor - Arc.Pos;
			if (DRAW_POST_RADIUS < Math.Abs(oc.Norm - Arc.Radius)) {
				return false;
			}
			var ocSweep = oc.Angle * 180 / Math.PI - Arc.Begin;
			if (ocSweep < 0) {
				ocSweep += 360;
			} else {
				ocSweep -= 360 * ((int)ocSweep / 360);
			}
			if (ocSweep < 0 || Arc.Sweep < ocSweep) {
				return false;
			}
			return true;
		}

		public override void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			xml.WriteAttributeString("x", Pos.X.ToString());
			xml.WriteAttributeString("y", Pos.Y.ToString());
			xml.WriteAttributeString("r", Arc.Radius.ToString("g4"));
			xml.WriteEndElement();
		}

		public override void ReadAttr(XmlReader xml) {
			switch (xml.Name.ToLower()) {
			case "x":
				Pos.X = double.Parse(xml.Value);
				break;
			case "y":
				Pos.Y = double.Parse(xml.Value);
				break;
			case "r":
				Arc.Radius = double.Parse(xml.Value);
				break;
			}
		}

		public override void Move(vec2 delta) {
			A.Pos += delta;
			Pos += delta;
			B.Pos += delta;
			P += delta;
			Q += delta;
			Arc.Pos += delta;
		}

		public override void Draw(Graphics g) {
			DrawLine(g, A.Pos, P);
			DrawLine(g, Q, B.Pos);
			Arc.Draw(g);
		}

		public override void DrawHighlight(Graphics g) {
			DrawArc(g, false, Arc.Pos, Arc.Radius);
			DrawLine(g, P, Pos);
			DrawLine(g, Pos, Q);
			DrawLine(g, A.Pos, P, true);
			DrawLine(g, Q, B.Pos, true);
			Arc.DrawHighlight(g);
			DrawPost(g, Pos);
			A.Draw(g);
			B.Draw(g);
		}

		public void Calc(double distance = 0) {
			var a = A.Pos - Pos;
			var b = B.Pos - Pos;
			var aLen = a.Norm;
			var bLen = b.Norm;
			var c = (a / aLen) + (b / bLen);

			if (distance <= 0) {
				var d = Math.Min(1000, Arc.Radius / Math.Sin(Math.Abs(c.Angle - a.Angle)));
				c *= d / c.Norm;
			}
			else {
				c *= distance / c.Norm;
			}

			var t = a * c / aLen / aLen;
			var u = b * c / bLen / bLen;
			if (t < 0) {
				t = 0;
			}
			if (1 < t) {
				t = 1;
			}
			if (u < 0) {
				u = 0;
			}
			if (1 < u) {
				u = 1;
			}

			var p = t * a;
			var q = u * b;
			P = p + Pos;
			Q = q + Pos;
			Arc.Pos = c + Pos;

			var cp = p - c;
			var cq = q - c;
			var cpAngle = cp.Angle * 180 / Math.PI;
			var cqAngle = cq.Angle * 180 / Math.PI;
			if (cpAngle < 0) {
				cpAngle += 360;
			}
			if (cqAngle < 0) {
				cqAngle += 360;
			}

			if (cpAngle < cqAngle) {
				Arc.Begin = cqAngle;
				Arc.Sweep = -(cqAngle - cpAngle);
			}
			else {
				Arc.Begin = cpAngle;
				Arc.Sweep = -(cpAngle - cqAngle);
			}
			Arc.Radius = cp.Norm;
		}

		public List<Post> GetPolyline(Group group) {
			var ret = new List<Post>();
			var r = Radius;
			var div = (int)Math.Max(1, 4 * r * Math.Abs(Arc.Sweep) / 90 + 0.5);
			var th = Arc.Begin * Math.PI / 180;
			var dth = Arc.Sweep * Math.PI / 180 / div;
			for (var i = 0; i < div; i++) {
				ret.Add(new Post() {
					Parent = Parent,
					Pos = vec2.FromPhaser(r, th, Arc.Pos)
				});
				th += dth;
			}
			return ret;
		}
	}
}
