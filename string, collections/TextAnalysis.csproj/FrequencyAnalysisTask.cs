using System.Collections.Generic;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            text = new List<List<string>> { new List<string> { "a", "b", "c", "d" }, new List<string> { "b", "c", "d" }, new List<string> { "e", "b", "c", "a", "d" } };
            var dict = new Dictionary<string, Dictionary<string,int>>();
            var result = new Dictionary<string, string>();
            for (int i=0;i<text.Count;i++)
            {
                for(int j=0;j<text[i].Count;j++)
                {
                    if (!dict.ContainsKey(text[i][j])) dict.Add(text[i][j], new Dictionary<string, int>());
                }
            }
            var k = GetNSize("b","c d",text);
            return result;
        }
        public static Dictionary<string, int> GetNSize(string startWord, string endWord, List<List<string>> text)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            for (int i=0;i<text.Count;i++)
            {
                for(int j=0;j<text[i].Count;j++)
                {
                    if (text[i][j] == startWord && text[i][j + 1] == endWord)
                    {
                        if (res.ContainsKey(text[i][j + 1])) res[text[i][j + 1]]++;
                        else res.Add(text[i][j + 1], 1);
                    }
                }
            }
            return res;
        }
   }
}