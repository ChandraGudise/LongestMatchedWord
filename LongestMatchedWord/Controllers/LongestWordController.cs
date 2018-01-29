using LongestMatchedWord.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LongestMatchedWord.Controllers
{
    public class LongestWordController : ApiController
    {
        [HttpGet]
        public Word GetLongestMatchingWords()
        {
            List<string> matchingWords = new List<string>();
            Word word = new Word();

            if (File.Exists("C:\\NET Test 00.txt"))
            {
                var wordsFromFile = File.ReadAllLines("C:\\NET Test 00.txt").ToList().OrderByDescending(x => x.Length).ToList();
                if (!(wordsFromFile == null))
                {
                    matchingWords = MatchedWord.GetLongestWords(wordsFromFile).OrderByDescending(x => x.Length).ToList();
                    word.words.AddRange(matchingWords.Take(2).ToList());
                    word.count = matchingWords.Count;
                }
            }
            return word;
        }
    }
}
