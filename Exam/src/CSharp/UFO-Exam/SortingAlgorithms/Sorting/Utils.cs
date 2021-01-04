using System;

namespace SortingAlgorithms.Sorting {
    public class Utils {
        public static bool Less(string v, string w) {
            return string.Compare(v, w, StringComparison.Ordinal) < 0;
        }
        public static void Swap(string[] arr, int i, int j) {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        
        public static bool isSorted(string[] arr) {
            for (var i = 1; i < arr.Length; i++) {
                if (Less(arr[i], arr[i - 1])) {
                    Console.WriteLine($"{arr[i]} | {arr[i-1]}");
                    return false;
                }
            }

            return true;
        }
    }
}