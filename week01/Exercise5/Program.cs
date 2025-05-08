using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    //asks user for name and returns it
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }

    //Asks user for their favorite number
    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number? ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    
    //takes integer and returns it squared
    static int SquareNumber(int number)
    {
        return number * number;
    }

    //displays the result
    static void DisplayedResult(string name, int square)
    {
        Console.WriteLine($"Hello {name}, your favorite number squared is {square}.");
    }

    //main method
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayedResult(userName, square);
    }

}