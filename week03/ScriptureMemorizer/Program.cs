using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways acknowledge him, and he will make your paths straight.";
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide a word, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            scripture.HideRandomWord();
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("/nAll words are hidden. Press Enter to extit.");
        Console.ReadLine();
    }
}