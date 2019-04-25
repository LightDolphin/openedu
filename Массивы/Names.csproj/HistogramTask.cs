using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name), 
                new string[0], 
                new double[0]);
        }
    }
}