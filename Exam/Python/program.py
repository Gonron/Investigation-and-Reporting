import sys
import quick
import time
from text_processor import sanitize_string, read_file

# Changes the default recursion limit
sys.setrecursionlimit(5000)

text = read_file('SomeText.txt')
words = sanitize_string(text)
 
start = time.time()
quick.sort(words)
time_elapsed = time.time() - start

print('davs')
print(time_elapsed)

