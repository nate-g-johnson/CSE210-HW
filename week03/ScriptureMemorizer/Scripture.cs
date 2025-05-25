using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0)
        {
            return; // All words are already hidden
        }

        visibleWords = visibleWords.OrderBy(w => _random.Next()).ToList();

        // Hide the specified number of words, but not more than what's available
        int wordsToHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            visibleWords[i].Hide();
        }
    }
    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {wordsText}";
    }
    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}