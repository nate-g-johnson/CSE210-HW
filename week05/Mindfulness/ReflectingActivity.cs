using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _originalPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _originalQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public void RunReflection()
    {
        DisplayStartingMessage();

        // Initialize queues with shuffled prompts/questions
        _promptQueue = new Queue<string>(ShuffleList(_originalPrompts));
        _questionQueue = new Queue<string>(ShuffleList(_originalQuestions));

        // Get prompt, reshuffle if empty
        if (_promptQueue.Count == 0)
            _promptQueue = new Queue<string>(ShuffleList(_originalPrompts));
        string prompt = _promptQueue.Dequeue();

        Console.WriteLine("\n" + prompt);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            if (_questionQueue.Count == 0)
                _questionQueue = new Queue<string>(ShuffleList(_originalQuestions));

            string question = _questionQueue.Dequeue();

            Console.WriteLine("\n" + question);
            ShowSpinner(5);  // 5 seconds pause with spinner animation

            if (DateTime.Now >= endTime)
                break;
        }

        DisplayEndingMessage();
    }

    private List<string> ShuffleList(List<string> list)
    {
        Random rand = new Random();
        return list.OrderBy(item => rand.Next()).ToList();
    }

    private void ShowSpinner(int seconds)
    {
        char[] spinner = new char[] { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
        }
    }
}
