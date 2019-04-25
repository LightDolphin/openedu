using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            text = " [a.b!c?d:e;f(g)h;i].";
            var sentencesList = new List<List<string>>();
            string[] sentences = text.Split(".!?;:()".ToCharArray());
            List<string> words = new List<string>();
            foreach (string sentence in sentences)
            {
                if (sentence.Length > 0)
                {
                    words = WordsFromSentence(sentence);
                    if (words.Count!=0) sentencesList.Add(words);
                }
            }
            return sentencesList;
        }
        public static List<string> WordsFromSentence(string sentence)
        {
            List<string> words = new List<string>();
            StringBuilder builder = new StringBuilder();
            for (int i=0;i<sentence.Length;i++)
            {
                if (char.IsLetter(sentence[i]) || sentence[i] == '\'')
                {
                    builder.Insert(builder.Length, sentence[i]);
                    if (i == sentence.Length - 1)
                    {
                        words.Add(builder.ToString().ToLower());
                        builder.Remove(0, builder.Length);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(builder.ToString()) || !string.IsNullOrWhiteSpace(builder.ToString()))
                    {
                        words.Add(builder.ToString().ToLower());
                    }
                    builder.Remove(0, builder.Length);
                }
            }
            return words;
        }
    }
}