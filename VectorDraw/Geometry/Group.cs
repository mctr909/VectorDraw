using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Geometry {
	public class Group {
		public const string TagName = "group";
		const string DefaultName = "グループ";

		public Model Parent { get; private set; }
		public Layer Layer;
		public string Name = "";
		public int Pix = 4;
		public double Scale = 2.54;
		public vec2 Origin;
		public List<BaseGeometry> Items = new List<BaseGeometry>();

		string mLayerName = "";

		public Group() { }

		public Group(Model model, XmlReader xml) {
			Parent = model;
			while (xml.MoveToNextAttribute()) {
				switch (xml.Name.ToLower()) {
				case "name":
					Name = xml.Value;
					break;
				case "layer":
					mLayerName = xml.Value;
					break;
				case "pix":
					Pix = int.Parse(xml.Value);
					break;
				case "scale":
					Scale = double.Parse(xml.Value);
					break;
				case "x":
					Origin.X = double.Parse(xml.Value);
					break;
				case "y":
					Origin.Y = double.Parse(xml.Value);
					break;
				}
			}
			while (xml.Read()) {
				if (xml.NodeType == XmlNodeType.EndElement && xml.LocalName == TagName) {
					break;
				}
				if (xml.NodeType != XmlNodeType.Element) {
					continue;
				}
				switch (xml.LocalName.ToLower()) {
				case Post.TagName:
					Items.Add(new Post(xml));
					break;
				case Polyline.TagName:
					Items.Add(new Polyline(xml, this));
					break;
				case Polygon.TagName:
					Items.Add(new Polygon(xml, this));
					break;
				default:
					break;
				}
			}
		}

		public void SetLayer(List<Layer> layers) {
			Layer = layers.Find((layer) => layer.Name == mLayerName);
		}

		public void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			if (!string.IsNullOrEmpty(Name)) {
				xml.WriteAttributeString("name", Name);
			}
			xml.WriteAttributeString("layer", Layer.Name);
			xml.WriteAttributeString("pix", Pix.ToString());
			xml.WriteAttributeString("scale", Scale.ToString("f2"));
			xml.WriteAttributeString("x", Origin.X.ToString("g4"));
			xml.WriteAttributeString("y", Origin.Y.ToString("g4"));
			foreach (var item in Items) {
				item.Write(xml);
			}
			xml.WriteEndElement();
		}

		public static Group Add(Model model, Layer layer, string name = "") {
			var defaultNameCount = 1;
			foreach (var item in model.Groups) {
				if (!item.Name.Contains(DefaultName)) {
					continue;
				}
				var strNum = item.Name.Replace(DefaultName, "");
				if (string.IsNullOrEmpty(strNum)) {
					continue;
				}
				strNum = Regex.Replace(strNum, "[^0-9]", "");
				if (string.IsNullOrEmpty(strNum)) {
					continue;
				}
				defaultNameCount = Math.Max(defaultNameCount, int.Parse(strNum) + 1);
			}
			var ret = new Group() {
				Parent = model,
				Layer = layer,
				Name = string.IsNullOrEmpty(name) ? (DefaultName + defaultNameCount) : name
			};
			model.Groups.Add(ret);
			return ret;
		}
	}
}
