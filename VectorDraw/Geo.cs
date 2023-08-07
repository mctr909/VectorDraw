using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Geo;

class Geo {
    public struct Surface {
        public PointF a;
        public PointF o;
        public PointF b;
    }
    struct VertInfo {
        public double distance;
        public bool deleted;
    };

    public static bool HasInnerPoint(Surface s, PointF p) {
        return HasInnerPoint(s.a, s.o, s.b, p);
    }

    public static bool HasInnerPoint(PointF a, PointF o, PointF b, PointF p) {
        var aoX = o.X - a.X;
        var aoY = o.Y - a.Y;
        var opX = p.X - o.X;
        var opY = p.Y - o.Y;
        var na = aoX * opY - aoY * opX;
        var obX = b.X - o.X;
        var obY = b.Y - o.Y;
        var bpX = p.X - b.X;
        var bpY = p.Y - b.Y;
        var no = obX * bpY - obY * bpX;
        var baX = a.X - b.X;
        var baY = a.Y - b.Y;
        var apX = p.X - a.X;
        var apY = p.Y - a.Y;
        var nb = baX * apY - baY * apX;
        return (0 < na && 0 < no && 0 < nb) || (na < 0 && no < 0 && nb < 0);
    }

    public static List<Surface> GetTriangle(PointF[] poly, int order) {
        int INDEX_COUNT = poly.Length;
        int INDEX_NEXT = INDEX_COUNT + order;
        int INDEX_RIGHT = 1;
        int INDEX_LEFT = INDEX_COUNT - 1;

        var surfList = new List<Surface>();

        var vert_info = new VertInfo[INDEX_COUNT];
        for (var i = 0; i < INDEX_COUNT; i++) {
            var x = poly[i].X - int.MinValue;
            var y = poly[i].Y - int.MinValue;
            vert_info[i].distance = Math.Sqrt(x * x + y * y);
            vert_info[i].deleted = false;
        }

        double area = 0.0;
        uint reverse_count = 0;
        uint vert_count = 0;
        do { // 最も遠くにある頂点(vo)の取得ループ
            /*** 最も遠くにある頂点(vo)を取得 ***/
            PointF vo; uint io = 0;
            double dist_max = 0.0;
            vert_count = 0;
            for (uint i = 0; i < INDEX_COUNT; i++) {
                var info = vert_info[i];
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
                PointF va; uint ia;
                ia = (uint)((io + INDEX_LEFT) % INDEX_COUNT);
                for (uint i = 0; i < INDEX_COUNT; i++) {
                    if (vert_info[ia].deleted) {
                        ia = (uint)((ia + INDEX_LEFT) % INDEX_COUNT);
                    } else {
                        break;
                    }
                }
                va = poly[ia];
                /*** 頂点(vo)の右隣にある頂点(vb)を取得 ***/
                PointF vb; uint ib;
                ib = (uint)((io + INDEX_RIGHT) % INDEX_COUNT);
                for (uint i = 0; i < INDEX_COUNT; i++) {
                    if (vert_info[ib].deleted) {
                        ib = (uint)((ib + INDEX_RIGHT) % INDEX_COUNT);
                    } else {
                        break;
                    }
                }
                vb = poly[ib];
                /*** 三角形(va vo vb)の表裏を確認 ***/
                float aob_normal;
                var oa_x = va.X - vo.X;
                var oa_y = va.Y - vo.Y;
                var ob_x = vb.X - vo.X;
                var ob_y = vb.Y - vo.Y;
                aob_normal = (oa_x * ob_y - oa_y * ob_x) * order;
                if (aob_normal < 0) {
                    /*** 裏の場合 ***/
                    reverse_count++;
                    if (INDEX_COUNT < reverse_count) {
                        /*** 表になる三角形(va vo vb)がない場合 ***/
                        /*** 頂点(vo)を検索対象から削除 ***/
                        vert_info[io].deleted = true;
                        /*** 次の最も遠くにある頂点(vo)を取得 ***/
                        break;
                    }
                    /*** 頂点(vo)を隣に移動 ***/
                    io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
                    for (uint i = 0; i < INDEX_COUNT; i++) {
                        if (vert_info[io].deleted) {
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
                    if (i == ia || i == io || i == ib || vert_info[i].deleted) {
                        continue;
                    }
                    var p = poly[i];
                    if (HasInnerPoint(va, vo, vb, p)) {
                        point_in_triangle = true;
                        break;
                    }
                }
                if (point_in_triangle) {
                    /*** 内側に他の頂点がある場合 ***/
                    /*** 頂点(vo)を隣に移動 ***/
                    io = (uint)((io + INDEX_NEXT) % INDEX_COUNT);
                    for (uint i = 0; i < INDEX_COUNT; i++) {
                        if (vert_info[io].deleted) {
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
                    vert_info[io].deleted = true;
                    /*** 次の最も遠くにある頂点(vo)を取得 ***/
                    break;
                }
            }
        } while (3 < vert_count); // 最も遠くにある頂点(vo)の取得ループ

        return surfList;
    }

    public static bool PointOnLine(PointF a, PointF b, PointF p, int limitDist = 5) {
        var abx = b.X - a.X;
        var aby = b.Y - a.Y;
        var apx = p.X - a.X;
        var apy = p.Y - a.Y;
        var abL2 = abx * abx + aby * aby;
        PointF q;
        if (0 == abL2) {
            q = a;
        } else {
            var r = (apx * abx + apy * aby) / abL2;
            if (r <= 0.0) {
                q = a;
            } else if (1.0 <= r) {
                q = b;
            } else {
                q = new PointF(abx * r + a.X, aby * r + a.Y);
            }
        }
        var pqx = q.X - p.X;
        var pqy = q.Y - p.Y;
        var pqL2 = pqx * pqx + pqy * pqy;
        return pqL2 < limitDist * limitDist;
    }
}
