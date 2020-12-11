def sort(arr):
    n = len(arr)
    _sort(arr, 0, n-1)
    
def _sort(arr, left, right):
    if len(arr) == 1:
        return arr
    if left < right:
        pivot = partition(arr, left, right)
        _sort(arr, left, pivot - 1)
        _sort(arr, pivot + 1, right)

def partition(arr, left, right):
    pivot = arr[right]
    i = left - 1 # Starting from last element -1
    for j in range(left, right):
        # If the current element is small then
        # the pivot, increment i and swap(i, j)
        if arr[j] <= pivot:
            i+=1
            arr[i], arr[j] = arr[j], arr[i]

    # swap arr[i+1] and arr[right] (or pivot)
    arr[i+1], arr[right] = arr[right], arr[i+1]
    return i + 1 