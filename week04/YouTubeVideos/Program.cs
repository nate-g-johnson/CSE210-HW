using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video { Title = "Rafting Adventure", Author = "OutdoorFun", Length = 320 };
        video1.AddComment(new Comment("John", "This looks so fun!"));
        video1.AddComment(new Comment("Alice", "I want to try this!"));
        video1.AddComment(new Comment("Mike", "Great camera angles."));
        videos.Add(video1);

        Video video2 = new Video { Title = "Tech Unboxing", Author = "GadgetPro", Length = 540 };
        video2.AddComment(new Comment("Sara", "Loved the review."));
        video2.AddComment(new Comment("Tom", "Can you do a comparison video?"));
        video2.AddComment(new Comment("Emma", "Very informative!"));
        videos.Add(video2);

        Video video3 = new Video { Title = "Cooking Pasta", Author = "ChefLina", Length = 275 };
        video3.AddComment(new Comment("Rob", "Yummy!"));
        video3.AddComment(new Comment("Jess", "Trying this tonight."));
        video3.AddComment(new Comment("Sam", "More vegetarian recipes please!"));
        videos.Add(video3);

        Video video4 = new Video { Title = "Learn C# Basics", Author = "CodeWithMe", Length = 680 };
        video4.AddComment(new Comment("Dave", "Thanks for making it simple."));
        video4.AddComment(new Comment("Linda", "Best tutorial ever."));
        video4.AddComment(new Comment("Nina", "Clear and concise."));
        videos.Add(video4);

        // Display all video info
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"  - {c.CommenterName}: {c.CommentText}");
            }

            Console.WriteLine();
        }
    }
}
