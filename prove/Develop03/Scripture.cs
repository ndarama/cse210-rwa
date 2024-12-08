using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; private set; }
    private List<Word> Words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Hide a few random words
    public void HideRandomWords(int count)
    {
        Random random = new Random();
        var visibleWords = Words.Where(word => !word.IsHidden).ToList();

        for (int i = 0; i < count && visibleWords.Any(); i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Check if all words are hidden
    public bool IsCompletelyHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    // Get the scripture textwith hidden words
    public string GetDisplayText()
    {
        return $"{Reference}\n{string.Join(" ", Words.Select(word => word.GetDisplayText()))}";
    }
}