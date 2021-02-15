using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MatchStringsInTextFile
{
    class Program
    {
        // match "words" consisting of 14 letters or digits
        private static readonly Regex vinRegex = new Regex(@"\b[A-Z0-9]{14}\b");
        private static readonly HashSet<string> set = new HashSet<string>();

        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("TextFile1.txt"))
            {
                // read entire text file into the string
                string resourceContents = reader.ReadToEnd();

                // remove hash characters followed by anything
                string commentsRemoved = Regex.Replace(resourceContents, @"#.*$", string.Empty, RegexOptions.Multiline);
                Console.WriteLine("commentsRemoved: " + commentsRemoved);

                // extract words and store them into the set
                foreach (Match match in vinRegex.Matches(commentsRemoved))
                {
                    set.Add(match.Value.ToUpper());
                }
            }

            foreach (string key in set)
            {
                Console.WriteLine("key: " + key);
            }

            // do not close the CMD console immediately
            Console.ReadKey();
        }
    }
}
