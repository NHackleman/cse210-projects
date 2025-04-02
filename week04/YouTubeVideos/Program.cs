using System;
using System.Collections.Generic;

class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public string GetCommenterName()
    {
        return _commenterName;
    }

    public string GetText()
    {
        return _text;
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comment> _comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string text)
    {
        Comment comment = new Comment(commenterName, text);
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {
        return _lengthInSeconds;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C# Programming", "CodeMaster", 720);
        video1.AddComment("John Doe", "This tutorial helped me understand classes!");
        video1.AddComment("Jane Smith", "Great explanation of inheritance.");
        video1.AddComment("Bob Johnson", "Could you make a video about interfaces next?");
        videos.Add(video1);

        Video video2 = new Video("Cooking Italian Pasta", "ChefExtraordinaire", 480);
        video2.AddComment("Pasta Lover", "I tried this recipe and it was delicious!");
        video2.AddComment("Beginner Cook", "The instructions were easy to follow.");
        video2.AddComment("Food Critic", "Authentic technique, well explained.");
        video2.AddComment("Health Nut", "Can you suggest a whole grain alternative?");
        videos.Add(video2);

        Video video3 = new Video("Guitar Basics for Beginners", "MusicMaestro", 900);
        video3.AddComment("Future Guitarist", "Finally I can play my first chord!");
        video3.AddComment("Music Teacher", "I recommend this to all my students.");
        video3.AddComment("Rock Fan", "When will you cover power chords?");
        videos.Add(video3);

        Video video4 = new Video("DIY Home Repairs", "HandyPerson", 1200);
        video4.AddComment("Homeowner", "Fixed my leaky faucet thanks to you!");
        video4.AddComment("Apartment Dweller", "Are these repairs apartment-friendly?");
        video4.AddComment("Professional Plumber", "Good tips, but always call a pro for gas lines.");
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}