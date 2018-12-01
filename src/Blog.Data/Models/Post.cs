using System;

namespace Blog.Data.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
