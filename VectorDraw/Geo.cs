using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Geo {
    public struct Suface {
        public PointF a;
        public PointF o;
        public PointF b;
    }

    public static bool HasInnerPoint(Suface s, PointF p) {
        var aoX = s.o.X - s.a.X;
        var aoY = s.o.Y - s.a.Y;
        var opX = p.X - s.o.X;
        var opY = p.Y - s.o.Y;
        var na = aoX * opY - aoY * opX;
        var obX = s.b.X - s.o.X;
        var obY = s.b.Y - s.o.Y;
        var bpX = p.X - s.b.X;
        var bpY = p.Y - s.b.Y;
        var no = obX * bpY - obY * bpX;
        var baX = s.a.X - s.b.X;
        var baY = s.a.Y - s.b.Y;
        var apX = p.X - s.a.X;
        var apY = p.Y - s.a.Y;
        var nb = baX * apY - baY * apX;
        return (0 < na && 0 < no && 0 < nb) || (na < 0 && no < 0 && nb < 0);
    }

    public static List<Suface> GetTriangle(PointF[] poly) {
        return new List<Suface>();
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
