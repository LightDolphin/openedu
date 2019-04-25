using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
		// Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
		public static bool AreIntersected(Rectangle r1, Rectangle r2)
		{
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            if (Math.Min(r1.Right, r2.Right) >= Math.Max(r1.Left, r2.Left) && Math.Min(r1.Bottom, r2.Bottom) >= Math.Max(r1.Top, r2.Top))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (AreIntersected(r1, r2))
            {
                int buf = (Math.Min(r1.Right, r2.Right) - Math.Max(r1.Left, r2.Left)) * (Math.Min(r1.Bottom, r2.Bottom) - Math.Max(r1.Top, r2.Top));
                return buf > 0 ? buf : buf * -1;
            }
            else return 0;
		}

		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            int S = IntersectionSquare(r1, r2);
            if (S == r1.Width * r1.Height)
            {
                if (r1.Left <= r2.Right && r1.Left >= r2.Left && r1.Top >= r2.Top && r1.Top <= r2.Bottom && r1.Right >= r2.Left && r1.Right <= r2.Right && r1.Bottom >= r2.Top && r1.Bottom <= r2.Bottom) return 0;
                return -1;
            }
            else
            {
                if (S == r2.Width * r2.Height)
                {
                    if (r2.Left <= r1.Right && r2.Left >= r1.Left && r2.Top >= r1.Top && r2.Top <= r1.Bottom && r2.Right >= r1.Left && r2.Right <= r1.Right && r2.Bottom >= r1.Top && r2.Bottom <= r1.Bottom) return 1;
                    return -1;
                }
                return -1;
            }
        }
    }
}