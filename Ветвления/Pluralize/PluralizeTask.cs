namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
            if (count % 100 > 10 && count % 100 < 15)
            {
                return "рублей";
            }
            else
            {
                if (count % 10 == 3 || count % 10 == 2 || count % 10 == 4)
                {
                    return "рубля";
                }
                else
                {
                    if (count % 10 == 1) return "рубль";
                    else return "рублей";
                }
            }
		}
	}
}