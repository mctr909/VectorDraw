using System;
using System.Collections.Generic;

namespace Geometry {
	public class Polygon {
		enum EOrder {
			LEFT = -1,
			RIGHT = 1
		}

		struct Surface {
			public Vec2 a;
			public Vec2 o;
			public Vec2 b;
		}

		struct VertInfo {
			public double distance;
			public bool deleted;
		};

		static bool IsSelected(List<Surface> poly, Vec2 cursor) {
			foreach (var po in poly) {
				if (HasInnerPoint(cursor, po.a, po.o, po.b)) {
					return true;
				}
			}
			return false;
		}

		static List<Surface> GetSurface(Vec2[] poly, EOrder order) {
			int INDEX_COUNT = poly.Length;
			int INDEX_NEXT = INDEX_COUNT + (int)order;
			int INDEX_RIGHT = 1;
			int INDEX_LEFT = INDEX_COUNT - 1;

			var surfList = new List<Surface>();

			var vertInfo = new VertInfo[INDEX_COUNT];
			for (var i = 0; i < INDEX_COUNT; i++) {
				var d = poly[i] - Vec2.MinValue;
				vertInfo[i].distance = d.Norm;
				vertInfo[i].deleted = false;
			}

			double area = 0.0;
			uint reverse_count = 0;
			uint vert_count = 0;
			do { // 最も遠くにある頂点(vo)の取得ループ
				/*** 最も遠くにある頂点(vo)を取得 ***/
				Vec2 vo;
				uint io = 0;
				double dist_max = 0.0;
				vert_count = 0;
				for (uint i = 0; i < INDEX_COUNT; i++) {
					var info = vertInfo[i];
					if (info.deleted) {
						continue;
					}
					if (dist_max < info.distance) {
						dist_max = info.distance;
						io = i;
					}
					vert_count++;
				}
				reverse_count = 0;
				vo = poly[io];
				while (true) { // 頂点(vo)の移動ループ
					/*** 頂点(vo)の左隣にある頂点(va)を取得 ***/
					Vec2 va;
					uint ia;
					ia = (uint)((io + INDEX_LEFT) % INDEX_COUNT);
					for (uint i = 0; i < INDEX_COUNT; i++) {
						if (vertInfo[ia].deleted) {
							ia = (uint)((ia + INDEX_LEFT) % INDEX_COUNT);
						} else {
							break;
						}
					}
					va = poly[ia];
					/*** 頂点(vo)の右隣にある頂点(vb)を取得 ***/
					Vec2 vb;
					uint ib;
					ib = (uint)((io + INDEX_RIGHT) % INDEX_COUNT);
					for (uint i = 0; i < INDEX_COUNT; i++) {
						if (vertInfo[ib].deleted) {
							ib = (uint)((ib + INDEX_RIGHT) % INDEX_COUNT);
						} else {
							break;
						}
					}
					vb = poly[ib];
					/*** 三角形(va vo vb)の表裏を確認 ***/
					double aob_normal;
					var oa = va - vo;
					var ob = vb - vo;
					aob_normal = oa * ob * (int)order;
					if (aob_normal < 0) {
						/*** 裏の場合 ***/
						reverse_count++;
						if (INDEX_COUNT < reverse_count) {
							/*** 表になる三角形(va vo vb)がない場合 ***/
							/*** 頂点(vo)を検索対象から削除 ***/
							vertInfo[io].deleted = true;
							/*** 次の最も遠くにある頂点(vo)を取得 ***/
							break;
						}
						/*** 頂点(vo)を隣に移動 ***/
						io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
						for (uint i = 0; i < INDEX_COUNT; i++) {
							if (vertInfo[io].deleted) {
								io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
							} else {
								break;
							}
						}
						vo = poly[io];
						continue;
					}
					/*** 三角形(va vo vb)の内側にva vo vb以外の頂点がないか確認 ***/
					bool point_in_triangle = false;
					for (uint i = 0; i < INDEX_COUNT; i++) {
						if (i == ia || i == io || i == ib || vertInfo[i].deleted) {
							continue;
						}
						var p = poly[i];
						if (HasInnerPoint(p, va, vo, vb)) {
							point_in_triangle = true;
							break;
						}
					}
					if (point_in_triangle) {
						/*** 内側に他の頂点がある場合 ***/
						/*** 頂点(vo)を隣に移動 ***/
						io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
						for (uint i = 0; i < INDEX_COUNT; i++) {
							if (vertInfo[io].deleted) {
								io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
							} else {
								break;
							}
						}
						vo = poly[io];
					} else {
						/*** 内側に他の頂点がない場合 ***/
						/*** 三角形(va vo vb)を面リストに追加 ***/
						Surface surf;
						surf.a = poly[ia];
						surf.o = poly[io];
						surf.b = poly[ib];
						surfList.Add(surf);
						/*** 三角形の面積を加算 ***/
						area += Math.Abs(aob_normal) / 2.0;
						/*** 頂点(vo)を検索対象から削除 ***/
						vertInfo[io].deleted = true;
						/*** 次の最も遠くにある頂点(vo)を取得 ***/
						break;
					}
				}
			} while (3 < vert_count); // 最も遠くにある頂点(vo)の取得ループ

			return surfList;
		}

		public static bool HasInnerPoint(Vec2 cursor, Vec2 a, Vec2 o, Vec2 b) {
			var ao = o - a;
			var op = cursor - o;
			var na = ao * op;
			var ob = b - o;
			var bp = cursor - b;
			var no = ob * bp;
			var ba = a - b;
			var ap = cursor - a;
			var nb = ba * ap;
			return (na > 0 && no > 0 && nb > 0) || (na < 0 && no < 0 && nb < 0);
		}
	}
}
