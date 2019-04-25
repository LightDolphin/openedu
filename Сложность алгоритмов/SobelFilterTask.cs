using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var width = g.GetLength(0)+1;
            var height = g.GetLength(1)+1;
            var result = new double[width, height];
            return result;
        }
    }
}