using System.Drawing;
using System.Xml;

namespace Geometry {
	public class Post : BaseGeometry {
		public const string TagName = "p";

		public string Name = "";

		public Post() { }
		public Post(Post source) {
			Pos = new vec2(source.Pos);
		}
		public Post(XmlReader xml, BaseGeometry parent = null) : base(xml, parent) { }

		public override BaseGeometry GetPost(vec2 cursor) {
			return HasGrippedPost(Pos, cursor) ? this : null;
		}

		public override bool IsSelected(vec2 cursor) {
			return HasGrippedPost(Pos, cursor);
		}

		public override void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			xml.WriteAttributeString("x", Pos.X.ToString());
			xml.WriteAttributeString("y", Pos.Y.ToString());
			if (!string.IsNullOrEmpty(Name)) {
				xml.WriteAttributeString("name", Name);
			}
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
			case "name":
				Name = xml.Value;
				break;
			}
		}

		public override void Move(vec2 delta) {
			Pos += delta;
		}

		public override void Draw(Graphics g) {
			DrawPost(g, Pos);
		}

		public override void DrawHighlight(Graphics g) {
			DrawPost(g, Pos, true);
		}
	}
}
