using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double a = Math.Sqrt(Math.Pow(bx-ax,2) + Math.Pow(by-ay,2));
            if (a > 1e-9)
            {
                double aa = Math.Sqrt(Math.Pow(x - ax, 2) + Math.Pow(y - ay, 2));
                double ab = Math.Sqrt(Math.Pow(x - bx, 2) + Math.Pow(y - by, 2));
                double p = (aa + a + ab) / 2.0;
                double ha = 2.0 * Math.Sqrt(p * (p - a) * (p - aa) * (p - ab)) / a;
                return Math.Min(Math.Min(ha, aa), Math.Min(ha, ab));
            }
            else
            {
                return 0;
            }
        }
	}
}