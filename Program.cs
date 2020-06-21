using System;
using System.IO;
using System.Collections.Generic;

//Test comment
namespace HelloCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = args.Length > 0
                ? args[0]
                : "6of12.txt";
            if(!File.Exists(dictionary)){
                Console.WriteLine($"could not find {dictionary}");
                return;

            }

            var words = new List<string>();
            var forWords = new HashSet<string>();
            var backWords = new HashSet<string>();
            foreach(var word in File.ReadLines(dictionary)) {
                if(String.IsNullOrWhiteSpace(word)) continue;
                if(word.Length < 2) continue;
                words.Add(word.ToLower());
                forWords.Add(word.ToLower());
                backWords.Add(word.ToLower().Reverse());
            }
            
            foreach(var word in words) {
                if(backWords.Contains(word))
                    Console.WriteLine($"{word} {word.Reverse()}");
            }

        }
    }
    public static class Util
    {
        public static string Reverse(this string text) {
            if(text == null) return null;
            var chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
}
