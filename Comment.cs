using System;

namespace OOP4Vardzar
{
    internal struct Comment
    {
        public string AuthorNickname;
        public string Text;
        public DateTime CreatedAt;

        public Comment(string authorNickname, string text, DateTime createdAt)
        {
            AuthorNickname = authorNickname;
            Text = text;
            CreatedAt = createdAt;
        }
    }
}