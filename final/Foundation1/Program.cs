using System;
using System.Collections.Generic;

class Video {
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds) {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment) {
        comments.Add(comment);
    }

    public int GetNumComments() {
        return comments.Count;
    }

    public void DisplayDetails() {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments) {
            Console.WriteLine($"- {comment.Name}: {comment.Text}");
        }
        Console.WriteLine();
    }
}

class Comment {
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text) {
        Name = name;
        Text = text;
    }
}

class Program {
    static void Main(string[] args) {
        List<Video> videos = new List<Video>();

        // Creating videos
        Video video1 = new Video("Video Title 1", "Author 1", 180);
        video1.AddComment(new Comment("User1", "Great video!"));
        video1.AddComment(new Comment("User2", "Nice content!"));
        video1.AddComment(new Comment("User3", "Thanks for sharing!"));
        videos.Add(video1);

        Video video2 = new Video("Video Title 2", "Author 2", 240);
        video2.AddComment(new Comment("User4", "Informative video."));
        video2.AddComment(new Comment("User5", "Keep up the good work!"));
        videos.Add(video2);

        Video video3 = new Video("Video Title 3", "Author 3", 300);
        video3.AddComment(new Comment("User6", "Interesting topic!"));
        videos.Add(video3);

        // Displaying video details
        foreach (var video in videos) {
            video.DisplayDetails();
        }
    }
}
