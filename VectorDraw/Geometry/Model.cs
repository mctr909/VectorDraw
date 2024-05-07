using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace Geometry {
	public class Model {
		public const string TagName = "model";
		const string DefaultName = "モデル";

		public string Name;
		public List<Group> Groups = new List<Group>();

		public Model() { }

		public Model(XmlReader xml) {
			while (xml.MoveToNextAttribute()) {
				switch (xml.Name.ToLower()) {
				case "name":
					Name = xml.Value;
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
				if (xml.LocalName == Group.TagName) {
					Groups.Add(new Group(this, xml));
				}
			}
		}

		public void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			xml.WriteAttributeString("name", Name);
			foreach (var item in Groups) {
				item.Write(xml);
			}
			xml.WriteEndElement();
		}

		public static Model Add(List<Model> list, string name = "") {
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
			var ret = new Model() {
				Name = string.IsNullOrEmpty(name) ? (DefaultName + defaultNameCount) : name
			};
			list.Add(ret);
			return ret;
		}
	}
}
