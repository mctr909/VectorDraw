using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml;

namespace Geometry {
	public class Polyline : BasePolygon {
		public const string TagName = "polyline";

		public double Width = 1.0;

		PointF[] mLine = new PointF[0];

		public Polyline(List<BaseGeometry> line, Group group) : base(group) {
			foreach (var l in line) {
				l.Parent = this;
			}
			mItems.AddRange(line);
			Calc();
		}
		public Polyline(XmlReader xml, Group group) : base(xml, group) {
			Calc();
		}

		public override BaseGeometry GetPost(vec2 cursor) {
			if (mGrippedPost != null) {
				return null;
			}
			foreach (var i in mItems) {
				var post = i.GetPost(cursor);
				if (null != post) {
					return post;
				}
			}
			return null;
		}

		public override bool IsSelected(vec2 cursor) {
			if (mGrippedPost != null) {
				return false;
			}
			vec2 a, b;
			a = mItems[0].Pos;
			for(int i=1; i<mItems.Count; i++) {
				b = mItems[i].Pos;
				if (HasOnLinePoint(a, b, cursor)) {
					return true;
				}
				a = b;
			}
			return false;
		}

		public override void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			if (!string.IsNullOrEmpty(Name)) {
				xml.WriteAttributeString("name", Name);
			}
			xml.WriteAttributeString("width", Width.ToString("f2"));
			if (Color != Color.Transparent) {
				xml.WriteAttributeString("color", string.Format("{0}{1}{2}{3}",
					Color.B.ToString("X2"),
					Color.G.ToString("X2"),
					Color.R.ToString("X2"),
					Color.A.ToString("X2")
				));
			}

			foreach (var item in mItems) {
				item.Write(xml);
			}

			xml.WriteEndElement();
		}

		public override void ReadAttr(XmlReader xml) {
			switch (xml.Name.ToLower()) {
			case "name":
				Name = xml.Value;
				break;
			case "width":
				Width = double.Parse(xml.Value);
				break;
			case "color":
				Color = Color.FromArgb(
					byte.Parse(xml.Value.Substring(6, 2), NumberStyles.HexNumber),
					byte.Parse(xml.Value.Substring(4, 2), NumberStyles.HexNumber),
					byte.Parse(xml.Value.Substring(2, 2), NumberStyles.HexNumber),
					byte.Parse(xml.Value.Substring(0, 2), NumberStyles.HexNumber)
				);
				break;
			}
		}

		public override void ReadInner(XmlReader xml) {
			while (xml.Read()) {
				if (xml.NodeType == XmlNodeType.EndElement && xml.LocalName == TagName) {
					return;
				}
				if (xml.NodeType != XmlNodeType.Element) {
					continue;
				}
				switch (xml.LocalName.ToLower()) {
				case Post.TagName:
					mItems.Add(new Post(xml, this));
					break;
				case Corner.TagName:
					mItems.Add(new Corner(xml, this));
					break;
				default:
					break;
				}
			}
		}

		public override void Move(vec2 delta) {
		}

		public override void Draw(Graphics g) {
			if (mLine.Length < 2) {
				return;
			}
			if (mGrippedPost == null) {
				DrawLines(g, mLine);
			}
			else {
				var line = new PointF[mItems.Count];
				for (int i = 0; i < mItems.Count; i++) {
					line[i] = mItems[i].Pos.Point;
				}
				DrawLines(g, line, true);
			}
		}

		public override void DrawHighlight(Graphics g) {
			if (mLine.Length < 2) {
				return;
			}
			DrawLines(g, mLine, true);
			foreach (var post in mItems) {
				post.Draw(g);
			}
		}

		protected override void Calc() {
			var line = new List<BaseGeometry>(mItems);
			mLine = new PointF[line.Count];
			for (var i = 0; i < line.Count; i++) {
				mLine[i] = line[i].Pos.Point;
			}
		}
	}
}
