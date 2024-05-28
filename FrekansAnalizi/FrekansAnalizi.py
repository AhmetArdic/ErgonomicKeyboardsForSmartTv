# -*- coding: utf-8 -*-

from collections import defaultdict
import pandas as pd
import os

# Read the file
file_path = 'turkce.txt'
with open(file_path, 'r', encoding='utf-8') as file:
    text = file.read().lower()

# Dictionary to store letter pairs
letter_pairs = defaultdict(lambda: defaultdict(int))

# Count the letter pairs
for i in range(len(text) - 1):
    if text[i].isalpha() and text[i+1].isalpha():
        letter_pairs[text[i]][text[i+1]] += 1

# Find the top 4 most frequent letters following each letter
top_4_letters = {}
for letter in letter_pairs:
    sorted_letters = sorted(letter_pairs[letter].items(), key=lambda item: item[1], reverse=True)
    top_4_letters[letter] = [pair[0] for pair in sorted_letters[:4]]

# Sort the results alphabetically by the initial letter
sorted_top_4_letters = dict(sorted(top_4_letters.items()))

# Convert letter pairs to a pandas DataFrame
data = []

for letter1 in letter_pairs:
    for letter2 in letter_pairs[letter1]:
        data.append([letter1, letter2, letter_pairs[letter1][letter2]])

df = pd.DataFrame(data, columns=['Letter 1', 'Letter 2', 'Frequency'])

# Display results
print("Top 4 most frequent letters following each letter (sorted alphabetically):")
for letter, letters in sorted_top_4_letters.items():
    print(f"{letter}: {', '.join(letters)}")

print("\nLetter Pairs Frequency:")
print(df.head(10))  # Display first 10 rows

# Save results to a CSV file
output_path = 'letter_pairs_frequency.csv'
df.to_csv(output_path, index=False)
