using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grage percentage: ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        //Get letter grade

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        //If user passed or not and print a message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("You'll get it next time!");
        }

        //Get the sign of the letter grade
        int lastDigit = grade % 10;
        if (letter != "A" && letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        else if(letter == "A" && grade < 93)
            {
                sign = "-";
            }

            //Show the final grade with sign
            Console.WriteLine($"Your final grade is {letter}{sign}.");
        }
    }
}