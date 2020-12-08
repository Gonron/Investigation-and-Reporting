using System.IO;
using System.Text.RegularExpressions;

namespace SortingAlgorithms {
    public class TextProcessor {
        public string[] ProcessedStrings { get; private set; }

        private static string ReadText(string path) {
            return File.ReadAllText(path);
        }

        private static string[] SanitizeText(string text, string regexPattern) {
            var matches = Regex.Matches(text, regexPattern);
            var matchedStrings = new string[matches.Count];
            for (var i = 0; i < matches.Count; i++) {
                matchedStrings[i] = matches[i].ToString();
            }
            return matchedStrings;
        }

        public void ProcessTextFile(string path, string regexPattern) {
            var text = ReadText(path).ToLower();
            ProcessedStrings = SanitizeText(text, regexPattern);
        }
    }
}