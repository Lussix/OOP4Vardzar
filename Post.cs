using System;
using System.Collections.Generic;

namespace OOP4Vardzar
{
    internal class Post
    {
        public User Author { get; }
        public DateTime CreatedAt { get; }
        public string Text { get; }
        public int Likes { get; private set; }
        public List<Comment> Comments { get; } = new List<Comment>();

        public Post(User author, string text, DateTime createdAt)
        {
            Author = author;
            Text = text;
            CreatedAt = createdAt;
        }

        public void AddLike()
        {
            Likes++;
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public void Print()
        {
            Console.WriteLine("[" + CreatedAt.ToString("dd.MM.yyyy HH:mm") + "] " + Author.Nickname);
            Console.WriteLine(Text);
            Console.WriteLine("Лайків: " + Likes);

            if (Comments.Count == 0)
            {
                Console.WriteLine("Коментарів немає");
            }
            else
            {
                Console.WriteLine("Коментарі:");
                for (int i = 0; i < Comments.Count; i++)
                {
                    Comment c = Comments[i];
                    Console.WriteLine("  " + c.AuthorNickname + ": " + c.Text
                        + " (" + c.CreatedAt.ToString("dd.MM.yyyy HH:mm") + ")");
                }
            }

            Console.WriteLine("-----");
        }
    }
}