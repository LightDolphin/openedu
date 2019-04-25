using System;
using System.Linq;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		/* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
		public static double[,] MedianFilter(double[,] original)
        {
            for (int i = 0; i < original.GetLongLength(0); i++)
            {
                for (int j = 0; j < original.GetLongLength(1); j++)
                {
                    original[i, j] = MedianValue(GetElements(original,i,j));
                }
            }
            return original;
		}
        public static double MedianValue(double[] mas)
        {
            var sum = mas.Sum();
            var buf = .0;
            if (mas.Length%2==0)
            for (int i = 0; i < mas.Length; i++)
            {
                buf += mas[i];
                    if (buf >= sum / 2)
                        if (mas.Length % 2 == 0)
                        {
                            return i < mas.Length - 1 ? (mas[i] + mas[i + 1]) / 2 : (mas[i] + mas[i - 1]) / 2;
                        }
                        else return mas[i];
            }
            return mas.Last();
        }
        public static double[] GetElements(double[,] original,int x,int y)
        {
            if (x == 0)
            {
                if (y == 0)
                {
                    return new double[] { original[x, y], original[x, y + 1], original[x + 1, y], original[x + 1, y + 1] };
                }
                else
                if (y == original.GetLength(1) - 1)
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x + 1, y], original[x + 1, y - 1] };
                }
                else
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x, y + 1], original[x+1, y], original[x+1, y - 1], original[x+1, y + 1] };
                }
            }
            else if (x == original.GetLength(0) - 1)
            {
                if (y == 0)
                {
                    return new double[] { original[x, y], original[x, y + 1], original[x - 1, y], original[x - 1, y + 1] };
                }
                else
                if (y == original.GetLength(1) - 1)
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x - 1, y], original[x - 1, y - 1] };
                }
                else
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x, y + 1], original[x - 1, y], original[x - 1, y - 1], original[x - 1, y + 1] };
                }
            }
            else
            {
                if (y == 0)
                {
                    return new double[] { original[x, y], original[x, y + 1], original[x+1, y], original[x + 1, y+1], original[x - 1, y], original[x - 1, y+1] };
                }
                else
                if (y == original.GetLength(1) - 1)
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x + 1, y], original[x + 1, y - 1], original[x - 1, y], original[x - 1, y - 1] };
                }
                else
                {
                    return new double[] { original[x, y], original[x, y - 1], original[x, y + 1], original[x + 1, y], original[x + 1, y - 1], original[x + 1, y + 1], original[x - 1, y], original[x - 1, y - 1], original[x - 1, y + 1] };
                }
            }
        }

	}
}