using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LongestMatchedWord
{
    public class MatchedWord
    {
        public static List<string> GetLongestWords(List<string> sortedWords)
        {
            List<string> longestWords = new List<string>();
            var dict = new HashSet<String>(sortedWords);
            foreach (var word in sortedWords)
            {
                if (IsWordMatched(word, dict))
                {
                    longestWords.Add(word);
                }
            }
            return longestWords;
        }

        private static bool IsWordMatched(string word, HashSet<string> dict)
        {
            if (String.IsNullOrEmpty(word)) return false;
            if (word.Length == 1)
            {
                if (dict.Contains(word)) return true;
                else return false;
            }
            foreach (var pair in CreatePairs(word))
            {
                if (dict.Contains(pair.Item1))
                {
                    if (dict.Contains(pair.Item2))
                    {
                        return true;
                    }
                    else
                    {
                        return IsWordMatched(pair.Item2, dict);
                    }
                }
            }
            return false;
        }


        private static List<Tuple<string, string>> CreatePairs(string word)
        {
            var output = new List<Tuple<string, string>>();
            for (int i = 1; i < word.Length; i++)
            {
                output.Add(Tuple.Create(word.Substring(0, i), word.Substring(i)));
            }
            return output;
        }
    }
}