using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;

namespace Geometry {
	public abstract class BasePolygon : BaseGeometry {
		protected enum EOrder {
			LEFT = 1,
			RIGHT = -1
		}

		protected struct Surface {
			public vec2 a;
			public vec2 o;
			public vec2 b;
		}

		struct VertInfo {
			public double distance;
			public bool deleted;
		};

		public string Name = "";
		public Color Color = Color.Transparent;

		protected List<BaseGeometry> mItems = new List<BaseGeometry>();
		protected BaseGeometry mGrippedPost = null;
		protected Group mGroup;

		public BasePolygon(Group group) { mGroup = group; }
		public BasePolygon(XmlReader xml, Group group) : base(xml, null) { mGroup = group; }

		public override void SetGripPost(BaseGeometry post) {
			mGrippedPost = post;
			Calc();
		}

		protected static bool HasInnerPoint(Surface s, vec2 p) {
			var ao = s.o - s.a;
			var op = p - s.o;
			var na = ao ^ op;
			var ob = s.b - s.o;
			var bp = p - s.b;
			var no = ob ^ bp;
			var ba = s.a - s.b;
			var ap = p - s.a;
			var nb = ba ^ ap;
			return (0 <= na && 0 <= no && 0 <= nb) || (na <= 0 && no <= 0 && nb <= 0);
		}

		protected static List<Surface> GetSurface(List<BaseGeometry> poly, EOrder order) {
			var VERT_COUNT = poly.Count;
			var VERT_NEXT = VERT_COUNT + (int)order;
			var VERT_RIGHT = 1;
			var VERT_LEFT = VERT_COUNT - 1;

			var surfList = new List<Surface>();

			var vertInfo = new VertInfo[VERT_COUNT];
			for (var i = 0; i < VERT_COUNT; i++) {
				var x = poly[i].Pos.X - int.MinValue;
				var y = poly[i].Pos.Y - int.MinValue;
				vertInfo[i].distance = Math.Sqrt(x * x + y * y);
				vertInfo[i].deleted = false;
			}

			uint vertCount;
			do { // 最も遠くにある頂点(vo)の取得ループ
				/*** 最も遠くにある頂点(vo)を取得 ***/
				int vo = 0;
				double distMax = 0.0;
				vertCount = 0;
				for (int i = 0; i < VERT_COUNT; i++) {
					var info = vertInfo[i];
					if (info.deleted) {
						continue;
					}
					if (distMax < info.distance) {
						distMax = info.distance;
						vo = i;
					}
					vertCount++;
				}
				var forwardCount = 0;
				var reverseCount = 0;
				while (true) { // 頂点(vo)の移動ループ
					/*** 頂点(vo)の左隣にある頂点(va)を取得 ***/
					var va = (vo + VERT_LEFT) % VERT_COUNT;
					for (var i = 0; i < VERT_COUNT; i++) {
						if (vertInfo[va].deleted) {
							va = (va + VERT_LEFT) % VERT_COUNT;
						}
						else {
							break;
						}
					}
					/*** 頂点(vo)の右隣にある頂点(vb)を取得 ***/
					var vb = (vo + VERT_RIGHT) % VERT_COUNT;
					for (var i = 0; i < VERT_COUNT; i++) {
						if (vertInfo[vb].deleted) {
							vb = (vb + VERT_RIGHT) % VERT_COUNT;
						}
						else {
							break;
						}
					}
					/*** 三角形(va vo vb)の表裏を確認 ***/
					var surf = new Surface() {
						a = poly[va].Pos,
						o = poly[vo].Pos,
						b = poly[vb].Pos
					};
					var oa = surf.a - surf.o;
					var ob = surf.b - surf.o;
					var aobNormal = oa ^ ob * (int)order;
					if (aobNormal >= 0) {
						/*** 表の場合 ***/
						forwardCount++;
						if (forwardCount > VERT_COUNT) {
							/*** 表の三角形(va vo vb)が頂点の数を超える場合 ***/
							/*** 三角形(va vo vb)を面リストに追加 ***/
							surfList.Add(surf);
							/*** 頂点(vo)を検索対象から削除 ***/
							vertInfo[vo].deleted = true;
							/*** 次の最も遠くにある頂点(vo)を取得 ***/
							break;
						}
					}
					else {
						/*** 裏の場合 ***/
						reverseCount++;
						if (reverseCount > VERT_COUNT) {
							/*** 表の三角形(va vo vb)がない場合 ***/
							/*** 頂点(vo)を検索対象から削除 ***/
							vertInfo[vo].deleted = true;
							/*** 次の最も遠くにある頂点(vo)を取得 ***/
							break;
						}
						/*** 頂点(vo)を隣に移動 ***/
						vo = (vo + VERT_NEXT) % VERT_COUNT;
						for (var i = 0; i < VERT_COUNT; i++) {
							if (vertInfo[vo].deleted) {
								vo = (vo + VERT_NEXT) % VERT_COUNT;
							}
							else {
								break;
							}
						}
						continue;
					}
					/*** 三角形(va vo vb)の内側にva vo vb以外の頂点がないか確認 ***/
					bool hasInnerVert = false;
					for (int i = 0; i < VERT_COUNT; i++) {
						if (i == va || i == vo || i == vb || vertInfo[i].deleted) {
							continue;
						}
						if (HasInnerPoint(surf, poly[i].Pos)) {
							hasInnerVert = true;
							break;
						}
					}
					if (hasInnerVert) {
						/*** 内側に他の頂点がある場合 ***/
						/*** 頂点(vo)を隣に移動 ***/
						vo = (vo + VERT_NEXT) % VERT_COUNT;
						for (var i = 0; i < VERT_COUNT; i++) {
							if (vertInfo[vo].deleted) {
								vo = (vo + VERT_NEXT) % VERT_COUNT;
							}
							else {
								break;
							}
						}
					}
					else {
						/*** 内側に他の頂点がない場合 ***/
						/*** 三角形(va vo vb)を面リストに追加 ***/
						surfList.Add(surf);
						/*** 頂点(vo)を検索対象から削除 ***/
						vertInfo[vo].deleted = true;
						/*** 次の最も遠くにある頂点(vo)を取得 ***/
						break;
					}
				}
			} while (3 < vertCount); // 最も遠くにある頂点(vo)の取得ループ

			return surfList;
		}

		protected abstract void Calc();
	}
}
