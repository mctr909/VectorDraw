using System;
using System.Drawing;
using System.Xml;

namespace Geometry {
	public class Arc : BaseGeometry {
		public const string TagName = "a";

		public double Radius;
		public double Begin;
		public double Sweep;

		public override BaseGeometry GetPost(vec2 cursor) {
			return null;
		}

		public override bool IsSelected(vec2 cursor) {
			var oc = cursor - Pos;
			if (DRAW_POST_RADIUS < Math.Abs(oc.Norm - Radius)) {
				return false;
			}
			var ocSweep = oc.Angle * 180 / Math.PI - Begin;
			if (ocSweep < 0) {
				ocSweep += 360;
			} else {
				ocSweep -= 360 * ((int)ocSweep / 360);
			}
			if (ocSweep < 0 || Sweep < ocSweep) {
				return false;
			}
			return true;
		}

		public override void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			xml.WriteAttributeString("x", Pos.X.ToString());
			xml.WriteAttributeString("y", Pos.Y.ToString());
			xml.WriteAttributeString("r", Radius.ToString("g4"));
			xml.WriteAttributeString("begin", Begin.ToString("f1"));
			xml.WriteAttributeString("sweep", Sweep.ToString("f1"));
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
				Radius = double.Parse(xml.Value);
				break;
			case "begin":
				Begin = double.Parse(xml.Value);
				break;
			case "sweep":
				Sweep = double.Parse(xml.Value);
				break;
			}
		}

		public override void Move(vec2 delta) {
			Pos += delta;
		}

		public override void Draw(Graphics g) {
			DrawArc(g, false, Pos, Radius, Sweep, Begin);
		}

		public override void DrawHighlight(Graphics g) {
			DrawArc(g, true, Pos, Radius, Sweep, Begin);
			DrawPost(g, Pos);
			var th = Math.PI * Begin / 180;
			var a = vec2.FromPhaser(Radius, th, Pos);
			DrawPost(g, a);
			th += Math.PI * Sweep / 180;
			var b = vec2.FromPhaser(Radius, th, Pos);
			DrawPost(g, b);
		}
	}
}
