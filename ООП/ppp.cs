using System;
namespace GeometryTasks
{
    public class Vector
    {
        public double X;
        public double Y;
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public Vector Add(Vector v2)
        {
            return Geometry.Add(this, v2);
        }

        public bool Belongs(Segment s)
        {
            return Geometry.IsVectorInSegment(this, s);
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y);
        }

        public static double GetLength(Segment s)
        {
            return Math.Sqrt((s.End.X - s.Begin.X) *
                             (s.End.X - s.Begin.X) +
                             (s.End.Y - s.Begin.Y) *
                             (s.End.Y - s.Begin.Y));
        }

        public static bool IsVectorInSegment(Vector v, Segment s)
        {
            if ((v.X - s.Begin.X) / (s.End.X - s.Begin.X) ==
                (v.Y - s.Begin.Y) / (s.End.Y - s.Begin.Y) ||
                v.X - s.Begin.X == 0 || s.End.X - s.Begin.X == 0)
            {
                if (v.X >= Math.Min(s.Begin.X, s.End.X) &&
                    v.X <= Math.Max(s.Begin.X, s.End.X) &&
                    v.Y >= Math.Min(s.Begin.Y, s.End.Y) &&
                    v.Y <= Math.Max(s.Begin.Y, s.End.Y)) return true;
            }
            return false;
        }

        public static Vector Add(Vector v1, Vector v2)
        {
            return new Vector() { X = v1.X + v2.X, Y = v1.Y + v2.Y };
        }
    }

    public class Segment
    {
        public Vector Begin;
        public Vector End;
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public bool Contains(Vector v)
        {
            return Geometry.IsVectorInSegment(v, this);
        }
    }
}


