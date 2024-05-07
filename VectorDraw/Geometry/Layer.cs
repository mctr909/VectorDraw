using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Geometry {
	public class Layer {
		public const string TagName = "layer";
		const string DefaultName = "レイヤー";

		public double Depth;
		public string Name;

		public Layer() { }

		public Layer(XmlReader xml) {
			while (xml.MoveToNextAttribute()) {
				switch (xml.Name.ToLower()) {
				case "name":
					Name = xml.Value;
					break;
				case "depth":
					Depth = double.Parse(xml.Value);
					break;
				}
			}
		}

		public void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			xml.WriteAttributeString("name", Name);
			xml.WriteAttributeString("depth", Depth.ToString("f2"));
			xml.WriteEndElement();
		}

		public static Layer Add(List<Layer> list, string name = "", double depth = 0.0) {
			var defaultNameCount = 1;
			foreach (var item in list) {
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
			var ret = new Layer() {
				Name = string.IsNullOrEmpty(name) ? (DefaultName + defaultNameCount) : name,
				Depth = depth
			};
			list.Add(ret);
			return ret;
		}
	}
}
