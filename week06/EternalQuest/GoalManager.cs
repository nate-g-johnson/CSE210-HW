using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _xp = 0;
    private int _level = 1;

    public void Start()
    {
        string choice;
        do
        {
            Console.WriteLine($"\nYou have {_score} points | Level {_level} | XP {_xp}/100");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }

        } while (choice != "6");
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Enter target times: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select the goal you accomplished:");
        ListGoalDetails();
        Console.Write("Enter number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            GainXP(points);
            Console.WriteLine($"You earned {points} points!");
        }
    }

    private void GainXP(int amount)
    {
        _xp += amount;
        while (_xp >= 100)
        {
            _xp -= 100;
            _level++;
            Console.WriteLine("***Level up*** You are now level " + _level + "!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter file name: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            writer.WriteLine(_xp);
            writer.WriteLine(_level);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("Enter file name: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);
            _xp = int.Parse(lines[1]);
            _level = int.Parse(lines[2]);
            _goals.Clear();

            for (int i = 3; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    bool isComplete = bool.Parse(parts[4]);

                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);

                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    string name = parts[1];
                    string description = parts[2];
                    int points = int.Parse(parts[3]);
                    int bonus = int.Parse(parts[4]);
                    int target = int.Parse(parts[5]);
                    int amountCompleted = int.Parse(parts[6]);

                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
