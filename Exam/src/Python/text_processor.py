import re

def read_file(path):
    with open(path, "r", encoding="utf-8-sig") as file:
        return file.read()


def sanitize_string(content):
    content = content.lower()
    return re.findall("[a-z]+'?-?[a-z]*", content)

