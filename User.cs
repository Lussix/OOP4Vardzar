using System;
using System.Collections.Generic;

namespace OOP4Vardzar
{
    internal class User
    {
        public string Name { get; }
        public string Email { get; }
        public string Nickname { get; }
        private List<Post> posts = new List<Post>();

        public User(string name, string email, string nickname)
        {
            Name = name;
            Email = email;
            Nickname = nickname;
        }

        public Post AddPost(string text, DateTime date)
        {
            Post post = new Post(this, text, date);
            posts.Add(post);
            return post;
        }

        public Post CreatePost(string text)
        {
            return AddPost(text, DateTime.Now);
        }

        public bool DeletePost(Post post)
        {
            if (post.Author != this)
            {
                return false;
            }

            return posts.Remove(post);
        }

        public List<Post> GetLastPosts(int count)
        {
            List<Post> result = new List<Post>();

            for (int i = posts.Count - 1; i >= 0 && result.Count < count; i--)
            {
                result.Add(posts[i]);
            }

            return result;
        }

        public void ShowLastPosts(User other)
        {
            List<Post> last = other.GetLastPosts(5);

            Console.WriteLine(Nickname + " дивиться останні пости користувача " + other.Nickname + ":");

            if (last.Count == 0)
            {
                Console.WriteLine("У користувача немає постів.");
                Console.WriteLine("-----");
                return;
            }

            for (int i = 0; i < last.Count; i++)
            {
                last[i].Print();
            }
        }

        public bool LikePost(Post post)
        {
            if (post.Author == this)
            {
                return false;
            }

            post.AddLike();
            return true;
        }

        public bool WriteComment(Post post, string text)
        {
            if (post.Author == this)
            {
                return false;
            }

            post.AddComment(new Comment(Nickname, text, DateTime.Now));
            return true;
        }
    }
}