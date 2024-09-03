using System;
using System.Collections.Generic;

namespace beyoy.BackgroundWorker
{
    public static class RandomWordsProvider
    {
        private static readonly List<string> _randomWords = new List<string>
        {
            "first one"
        };

        private static readonly Random _random = new Random();

        public static IReadOnlyList<string> RandomWordsForClient => _randomWords;

        public static void AddRandomWord(string word)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                _randomWords.Add(word);
            }
        }

        public static void GenerateRandomWord()
        {
           const int length = 3; 
           const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
           char[] randomChars = new char[length];

          for (int i = 0; i < length; i++)
          {
            randomChars[i] = chars[_random.Next(chars.Length)]; 
          }
          Console.WriteLine("string that is appended is "+  new string(randomChars));

          AddRandomWord(new string(randomChars));
        }

        public static void ClearRandomWords()
        {
            _randomWords.Clear(); 
        }
    }
}