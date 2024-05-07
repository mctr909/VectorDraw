using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml;

namespace Geometry {
	public class Polygon: BasePolygon {
		public const string TagName = "polygon";

		List<List<BaseGeometry>> mHoleList = new List<List<BaseGeometry>>();

		bool mSolidEditing = false;
		PointF[] mSolidOutline = new PointF[0];
		PointF[] mSolidPoly = new PointF[0];
		List<Surface> mSolidSurfaces = new List<Surface>();

		List<BaseGeometry> mEditingHole = null;
		List<Surface> mHoleSurfaces = new List<Surface>();
		List<PointF[]> mHoleOutlines = new List<PointF[]>();

		public Polygon(List<BaseGeometry> solid, Group group) : base(group) {
			foreach (var s in solid) {
				s.Parent = this;
			}
			mItems.AddRange(solid);
			//var count = solid.Count;
			//for (int i = 0; i < count; i++) {
			//	var a = solid[(i+count-1)%count];
			//	var b = solid[(i+1)%count];
			//	var o = new Corner() {
			//		Parent = this,
			//		Pos = solid[i].Pos,
			//		Radius = 8,
			//		A = new Post() {
			//			Parent = this,
			//			Pos = a.Pos
			//		},
			//		B = new Post() {
			//			Parent = this,
			//			Pos = b.Pos
			//		}
			//	};
			//	o.Calc();
			//	mItems.Add(o);
			//}
			Calc();
		}

		public Polygon(XmlReader xml, Group group) : base(xml, group) {
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
			foreach (var hole in mHoleList) {
				foreach (var i in hole) {
					var post = i.GetPost(cursor);
					if (null != post) {
						return post;
					}
				}
			}
			return null;
		}

		public override bool IsSelected(vec2 cursor) {
			if (mGrippedPost != null) {
				return false;
			}
			foreach (var s in mHoleSurfaces) {
				if (HasInnerPoint(s, cursor)) {
					return false;
				}
			}
			foreach (var s in mSolidSurfaces) {
				if (HasInnerPoint(s, cursor)) {
					return true;
				}
			}
			return false;
		}

		public override void Write(XmlWriter xml) {
			xml.WriteStartElement(TagName);
			if (!string.IsNullOrEmpty(Name)) {
				xml.WriteAttributeString("name", Name);
			}
			if (Color != Color.Transparent) {
				xml.WriteAttributeString("color", string.Format("{0}{1}{2}{3}",
					Color.B.ToString("X2"),
					Color.G.ToString("X2"),
					Color.R.ToString("X2"),
					Color.A.ToString("X2")
				));
			}

			xml.WriteStartElement("solid");
			foreach (var item in mItems) {
				item.Write(xml);
			}
			xml.WriteEndElement();

			foreach (var hole in mHoleList) {
				xml.WriteStartElement("hole");
				foreach (var item in hole) {
					item.Write(xml);
				}
				xml.WriteEndElement();
			}

			xml.WriteEndElement();
		}

		public override void ReadAttr(XmlReader xml) {
			switch (xml.Name.ToLower()) {
			case "name":
				Name = xml.Value;
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
				case "solid":
					ReadSolid(xml);
					break;
				case "hole":
					ReadHole(xml);
					break;
				default:
					break;
				}
			}
		}

		public override void Move(vec2 delta) {
		}

		public override void Draw(Graphics g) {
			if (mItems.Count < 3) {
				return;
			}

			FillPolygon(g, mSolidPoly);

			if (mSolidEditing) {
				var solidOutline = new PointF[mItems.Count];
				for (int i = 0; i < mItems.Count; i++) {
					solidOutline[i] = mItems[i].Pos.Point;
				}
				DrawPolygon(g, solidOutline, true);
			}
			else {
				DrawPolygon(g, mSolidOutline);
			}

			foreach (var hole in mHoleOutlines) {
				DrawHole(g, hole);
			}
			if (mEditingHole != null) {
				var hole = new PointF[mEditingHole.Count];
				for (int i = 0; i < mEditingHole.Count; i++) {
					hole[i] = mEditingHole[i].Pos.Point;
				}
				DrawHole(g, hole, true);
			}
		}

		public override void DrawHighlight(Graphics g) {
			if (mItems.Count < 3) {
				return;
			}

			FillPolygon(g, mSolidPoly, true);
			DrawPolygon(g, mSolidOutline, true);
			foreach (var hole in mHoleOutlines) {
				DrawHole(g, hole, true);
			}

			foreach (var post in mItems) {
				post.Draw(g);
			}
			foreach (var hole in mHoleList) {
				foreach (var post in hole) {
					post.Draw(g);
				}
			}
		}

		public void AddHole(List<BaseGeometry> hole) {
			foreach(var h in hole) {
				h.Parent = this;
			}
			mHoleList.Add(new List<BaseGeometry>(hole));
			Calc();
		}

		public void RemoveHole(vec2 cursor) {
			List<BaseGeometry> removeHole = null;
			foreach(var hole in mHoleList) {
				foreach(var p in hole) {
					if (p.IsSelected(cursor)) {
						removeHole = hole;
						break;
					}
				}
				if (removeHole != null) {
					mHoleList.Remove(removeHole);
					Calc();
					break;
				}
			}
		}

		protected override void Calc() {
			if (mItems.Count < 3) {
				return;
			}

			mSolidEditing = false;
			foreach (var post in mItems) {
				if (post == mGrippedPost) {
					mSolidEditing = true;
					break;
				}
			}

			mEditingHole = null;
			foreach (var hole in mHoleList) {
				foreach (var post in hole) {
					if (post == mGrippedPost) {
						mEditingHole = hole;
						break;
					}
				}
				if (mEditingHole != null) {
					break;
				}
			}

			var items = new List<BaseGeometry>();
			foreach (var item in mItems) {
				if (item is Corner c) {
					items.AddRange(c.GetPolyline(null));
				}
				else {
					items.Add(item);
				}
			}

			var sl = GetSurface(items, EOrder.LEFT);
			var sr = GetSurface(items, EOrder.RIGHT);
			var solidOrder = sl.Count > sr.Count ? EOrder.LEFT : EOrder.RIGHT;
			mSolidSurfaces.Clear();
			mSolidSurfaces.AddRange(sl.Count > sr.Count ? sl : sr);

			mHoleSurfaces.Clear();
			mHoleOutlines.Clear();
			var outline = new List<BaseGeometry>(items);
			foreach (var hole in mHoleList) {
				var hl = GetSurface(hole, EOrder.LEFT);
				var hr = GetSurface(hole, EOrder.RIGHT);
				var holeOrder = hl.Count > hr.Count ? EOrder.LEFT : EOrder.RIGHT;
				mHoleSurfaces.AddRange(hl.Count > hr.Count ? hl : hr);

				int idxDest = -1;
				int idxSrc = -1;
				var nearDist = double.MaxValue;
				for (int o = 0; o < outline.Count; o++) {
					var outlineP = outline[o];
					for (int h = 0; h < hole.Count; h++) {
						var s = outlineP.Pos - hole[h].Pos;
						var l2 = s * s;
						if (l2 < nearDist) {
							nearDist = l2;
							idxDest = o;
							idxSrc = h;
						}
					}
				}

				var holeStep = hole.Count + (holeOrder == solidOrder ? -1 : 1);
				var holeTemp = new List<BaseGeometry>();
				var holePoly = new PointF[hole.Count];
				for (int i = 0, s = idxSrc; i < hole.Count; i++, s = (s + holeStep) % hole.Count) {
					holeTemp.Add(hole[s]);
					holePoly[i] = hole[s].Pos.Point;
				}
				holeTemp.Add(hole[idxSrc]);
				if (mEditingHole != hole) {
					mHoleOutlines.Add(holePoly);
				}
				var newOutline = new List<BaseGeometry>();
				for (int i = 0; i <= idxDest; i++) {
					newOutline.Add(outline[i]);
				}
				newOutline.AddRange(holeTemp);
				for (int i = idxDest; i < outline.Count; i++) {
					newOutline.Add(outline[i]);
				}
				outline = newOutline;
			}

			mSolidOutline = new PointF[items.Count];
			for (var i = 0; i < items.Count; i++) {
				mSolidOutline[i] = items[i].Pos.Point;
			}
			mSolidPoly = new PointF[outline.Count];
			for (int i = 0; i < mSolidPoly.Length; i++) {
				mSolidPoly[i] = outline[i].Pos.Point;
			}
		}

		void ReadSolid(XmlReader xml) {
			while (xml.Read()) {
				if (xml.NodeType == XmlNodeType.EndElement && xml.LocalName == "solid") {
					break;
				}
				if (xml.NodeType != XmlNodeType.Element) {
					continue;
				}
				switch (xml.LocalName) {
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

		void ReadHole(XmlReader xml) {
			var holeItems = new List<BaseGeometry>();
			while (xml.Read()) {
				if (xml.NodeType == XmlNodeType.EndElement && xml.LocalName == "hole") {
					break;
				}
				if (xml.NodeType != XmlNodeType.Element) {
					continue;
				}
				switch (xml.LocalName) {
				case Post.TagName:
					holeItems.Add(new Post(xml, this));
					break;
				case Corner.TagName:
					holeItems.Add(new Corner(xml, this));
					break;
				default:
					break;
				}
			}
			mHoleList.Add(holeItems);
		}
	}
}
