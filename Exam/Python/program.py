import sys
from quick import sort
import time
import statistics 
from text_processor import sanitize_string, read_file

# Changes the default recursion limit
sys.setrecursionlimit(5000)

iterations = 250
times = []

for i in range(0, iterations):
    text = read_file('Data/SomeTextMedium.txt')
    words = sanitize_string(text)

    start = time.time()
    sort(words)
    time_elapsed = time.time() - start

    times.append(time_elapsed)



with open('../Data/pypy_medium.txt', 'a') as file:
    for x in range(len(times)):
        rec = str(times[x])
        file.write(f'{rec}\n')

total = sum(times)
avg = total / iterations
sdev = statistics.stdev(times)
sort(times)
print(f'Number of Chars: {len(words)}')
print(f'Total: {total}')
print(f'Min: {min(times)}')
print(f'Max: {max(times)}')
print(f'Median: {statistics.median(times)}')
print(f'Mean: {(max(times) + min(times)) / 2}')
print(f'Average: {avg}')
print(f'Standard Deviation: {sdev}')

