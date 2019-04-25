using System;
using System.Text;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            string[] days = new string[31];
            Console.WriteLine(Encoding.UTF8.GetBytes("БЩФzw!").Length);
            for (int i = 0; i < days.Length; i++) days[i] = (i + 1).ToString();

            string[] originalNames = OriginalNames(names);
            double[,] data = new double[31,originalNames.Length];
            //foreach (var name in names)
            //{
            //    for (int i = 0; i < originalNames.Length; i++)
            //    {
            //        if (originalNames[i] == name.Name && name.BirthDate.Day!=1) data[name.BirthDate.Day-1,i]+=1;
            //    }
            //}
            return new HeatmapData(
                "Карта интенсивностей", data ,days, originalNames);
        }
        public static string[] OriginalNames(NameData[] names)
        {
            bool b = true;
            int count = 0;
            for (int i = 1; i < names.Length; i++)
            {
                for (int j = i-1; j > 0; j--)
                {
                    if (string.Compare(names[i].Name,names[j].Name)==0)
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    count++;
                }
                b = true;
            }

            b = true;
            string[] original = new string[count];
            count = 0;
            for (int i = 1; i < names.Length; i++)
            {
                for (int j = i-1; j > 0; j--)
                {
                    if (names[i].Name == names[j].Name)
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    original[count] = names[i].Name;
                    count++;
                }
                b = true;
            }
            return original;
        }
    }
}