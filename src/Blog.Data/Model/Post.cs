using System;

namespace Blog.Data.Model
{
    public class Post : ICopiableModel<Post>
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreationDate { get; set; }

        public void CopyFrom(Post source)
        {
            this.UserId = source.UserId;
            this.Title = source.Title;
            this.Body = source.Body;
            this.CreationDate = source.CreationDate;
        }
    }
}
