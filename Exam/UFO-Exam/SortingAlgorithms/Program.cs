using System;
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
            
            const string fileName = "SomeText.txt";
            const string regex = @"[a-z]+'?-?[a-z]*";
            
            // This is to find the text files - Without having a long path string.
            Directory.SetCurrentDirectory(Path.Combine(Environment.CurrentDirectory, @"../../"));
            var path = $@"{Directory.GetCurrentDirectory()}\Data\{fileName}";
            

            
            for (var i = 0; i < iterations; i++) {
                var tp = new TextProcessor();
                tp.ProcessTextFile(path, regex);
                
                stopWatch.Start();
                Quick.Sort(tp.ProcessedStrings);
                stopWatch.Stop();
                
                times[i] = stopWatch.Elapsed;
                stopWatch.Reset();
            }

            /* Stackoverflow Solution
            var sumOfSquaresOfDifferences = times.Select(val => (val.TotalSeconds - avg) * (val.TotalSeconds - avg)).Sum();
            Console.WriteLine(Math.Sqrt(sumOfSquaresOfDifferences / times.Length));
            */
            
            var total = times.Sum(rec => rec.TotalSeconds);
            var avg = total / iterations;
            var top = times.Sum(rec => Math.Pow(rec.TotalSeconds - (total / iterations), 2));
            var bottom = times.Length;
            var sDiv = Math.Sqrt(top / bottom);
            
            Array.Sort(times);
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"Min: {times.Min()}");
            Console.WriteLine($"Max: {times.Max()}");
            Console.WriteLine(iterations % 2 == 0
                ? $"Median: {times[times.Length / 2]}"
                : $"Median: {times[times.Length / 2 + 1]}");
            Console.WriteLine($"Mean: {(times.Max().TotalSeconds + times.Min().TotalSeconds) / 2}");
            Console.WriteLine($"Average: {avg}");
            Console.WriteLine($"Standard Deviation: {sDiv}");
        }
    }
}