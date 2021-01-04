using System;
using System.CodeDom;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SortingAlgorithms.Sorting;

namespace SortingAlgorithms {
    class Program {
        public static void Main(string[] args) {
            var stopWatch = new Stopwatch();
            var iterations = 250;
            var times = new TimeSpan[iterations];

            const string timeStampPath = "../../Data/csharp_large.txt";
            const string fileName = "SomeTextLarge.txt";
            const string regex = @"[a-z]+'?-?[a-z]*";

            // This is to find the text files - Without having a long path string.
            Directory.SetCurrentDirectory(Path.Combine(Environment.CurrentDirectory, @"../../"));
            var path = $@"{Directory.GetCurrentDirectory()}\Data\{fileName}";
            
            var chars = 0;
            for (var i = 0; i < iterations; i++) {
                var tp = new TextProcessor();
                tp.ProcessTextFile(path, regex);
                chars = tp.ProcessedStrings.Length;
                
                stopWatch.Start();
                Quick.Sort(tp.ProcessedStrings);
                stopWatch.Stop();
                
                times[i] = stopWatch.Elapsed;
                //File.WriteAllText(timeStampPath,stopWatch.Elapsed.ToString().Substring(7).Replace('.',','));

                stopWatch.Reset();
            }
            
            /* Stackoverflow Solution
            var sumOfSquaresOfDifferences = times.Select(val => (val.TotalSeconds - avg) * (val.TotalSeconds - avg)).Sum();
            Console.WriteLine(Math.Sqrt(sumOfSquaresOfDifferences / times.Length));
            */
            
            // Stupid solution to write to a file...
            var arr = new string[iterations];
            for (var i = 0; i < iterations; i++) {
                arr[i] = times[i].ToString().Substring(7).Replace('.',',');
            }
            File.WriteAllLines(timeStampPath,arr);
            
            // Calculations for all the different measurements i need
            var total = times.Sum(rec => rec.TotalSeconds);
            var avg = total / iterations;
            var top = times.Sum(rec => Math.Pow(rec.TotalSeconds - (total / iterations), 2));
            var bottom = times.Length;
            var sDev = Math.Sqrt(top / bottom);
            Array.Sort(times);
            Console.WriteLine($"Number of Chars: {chars}");
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Min: {times.Min()}");
            Console.WriteLine($"Max: {times.Max()}");
            Console.WriteLine(iterations % 2 == 0
                ? $"Median: {times[times.Length / 2]}"
                : $"Median: {times[times.Length / 2 + 1]}");
            Console.WriteLine($"Mean: {(times.Max().TotalSeconds + times.Min().TotalSeconds) / 2}");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine($"Standard Deviation: {sDev}");
        }
    }
}