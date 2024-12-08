using System;
using System.Collections.Generic;

namespace YouTubeTracking
{
    // Comment Class
    public class Comment
    {
        public string Author { get; set; }
        public string Text { get; set; }

        public Comment(string author, string text)
        {
            Author = author;
            Text = text;
        }
    }

    // Video Class
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Length { get; set; } // Length in seconds
        private List<Comment> Comments { get; set; }

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            Length = length;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return Comments.Count;
        }

        public void DisplayVideoDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {Length} seconds");
            Console.WriteLine($"Number of Comments: {GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in Comments)
            {
                Console.WriteLine($" - {comment.Author}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }

    // Program Execution
    class Program
    {
        static void Main(string[] args)
        {
            // Creating videos
            var video1 = new Video("Learn C# in One Hour", "Code Academy", 3600);
            var video2 = new Video("Mastering Design Patterns", "Tech Guru", 4500);
            var video3 = new Video("Abstraction Explained", "Programming Basics", 1200);

            // Adding comments to video1
            video1.AddComment(new Comment("Alice", "Great tutorial!"));
            video1.AddComment(new Comment("Bob", "Very detailed explanation."));
            video1.AddComment(new Comment("Charlie", "Helped me a lot, thanks!"));

            // Adding comments to video2
            video2.AddComment(new Comment("Diana", "Finally understood patterns."));
            video2.AddComment(new Comment("Eve", "Clear and concise."));
            video2.AddComment(new Comment("Frank", "Best video on design patterns."));

            // Adding comments to video3
            video3.AddComment(new Comment("George", "Simple and effective!"));
            video3.AddComment(new Comment("Hannah", "Loved the examples."));
            video3.AddComment(new Comment("Ivy", "Quick and to the point."));

            // Storing videos in a list
            var videos = new List<Video> { video1, video2, video3 };

            // Displaying video details
            foreach (var video in videos)
            {
                video.DisplayVideoDetails();
            }
        }
    }
}
