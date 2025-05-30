using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option (1-4): ");

            string choice = Console.ReadLine();

            if (choice == "4") break;

            Console.Write("Enter duration in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.Write("Please enter a valid positive number: ");
            }

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.SetDuration(duration);
                    breathing.RunBreathing();
                    break;
                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.SetDuration(duration);
                    reflection.RunReflection();
                    break;
                case "3":
                    var listing = new ListingActivity();
                    listing.SetDuration(duration);
                    listing.RunListing();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                    break;
            }

            Console.WriteLine("\nPress Enter to return to menu...");
            Console.ReadLine();
        }
    }
}
