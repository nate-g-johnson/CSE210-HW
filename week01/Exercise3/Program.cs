using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while(playAgain.ToLower() == "yes")
        {
            //Random number between 1 and 100
            Random random = new Random();
            int randomNumber = random.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I have thought of a number between 1 and 100. Can you guess it?");

            //loop until the user guesses the number
            while (guess != randomNumber)
            {
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                if (guess < randomNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guess > randomNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("You guessed it!!!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }
            //Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }
        Console.WriteLine("Thanks for playing!");
    }
}