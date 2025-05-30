using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _originalPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Queue<string> _promptQueue;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public void RunListing()
    {
        DisplayStartingMessage();

        _promptQueue = new Queue<string>(ShuffleList(_originalPrompts));

        if (_promptQueue.Count == 0)
            _promptQueue = new Queue<string>(ShuffleList(_originalPrompts));
        string prompt = _promptQueue.Dequeue();

        Console.WriteLine("\nPrompt: " + prompt);
        Console.WriteLine("You may begin listing after the countdown:");

        PauseWithCountdown(5);  // 5 seconds to think

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                itemCount++;
        }

        Console.WriteLine($"\nYou listed {itemCount} items.");

        DisplayEndingMessage();
    }

    private List<string> ShuffleList(List<string> list)
    {
        Random rand = new Random();
        return list.OrderBy(item => rand.Next()).ToList();
    }

    private void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
