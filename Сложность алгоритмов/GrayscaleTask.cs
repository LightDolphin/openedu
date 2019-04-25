namespace Recognizer
{
	public static class GrayscaleTask
    {
		public static double[,] ToGrayscale(Pixel[,] original)
		{
            double[,] result = new double[original.GetLength(0), original.GetLength(1)];
            for (int i = 0; i < original.GetLongLength(0); i++)
            {
                for (int j = 0; j < original.GetLongLength(1); j++)
                {
                    result[i, j] = (.299 * original[i, j].R + .587 * original[i, j].G + .114 * original[i, j].B) / 255;
                }
            }
            return result;
		}
	}
}