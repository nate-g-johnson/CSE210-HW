using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void RunBreathing()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            PauseWithCountdown(4); // breathe in for 4 seconds
            Console.WriteLine("Breathe out...");
            PauseWithCountdown(6); // breathe out for 6 seconds
        }

        DisplayEndingMessage();
    }
}
