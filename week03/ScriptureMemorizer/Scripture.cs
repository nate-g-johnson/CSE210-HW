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

    public void HideRandomWord(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count <= count)
        {
            foreach (var word in visibleWords)
            {
                word.Hide();
            }
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                int index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
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