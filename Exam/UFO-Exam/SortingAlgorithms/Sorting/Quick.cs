using System;

namespace SortingAlgorithms.Sorting {
    public class Quick {
        public static void Sort(string[] arr) {
            var n = arr.Length;
            Sort(arr, 0, n - 1);
        }
        private static void Sort(string[] arr, int left, int right) {
            if (left < right) {
                var pivot = Partition(arr, left, right);
                Sort(arr, left, pivot - 1); 
                Sort(arr, pivot + 1, right);
            }
        }

        private static int Partition(string[] arr, int left, int right) {
            var pivot = arr[right];
            var i = left - 1; // Starting from last element -1
            for (var j = left; j < right; j++) {
                // If the current element is small then
                // the pivot, increment i and swap(i, j)
                if (Utils.Less(arr[j], pivot)) {
                    i++;
                    Utils.Swap(arr, i, j);
                    
                }
            }
            // swap arr[i+1] and arr[high] (or pivot)
            Utils.Swap(arr,i+1,right);
            return i + 1;
        }
    }
}