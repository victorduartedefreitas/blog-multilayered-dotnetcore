namespace Blog.Data.Model
{
    public class Comment : ICopiableModel<Comment>
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }

        public void CopyFrom(Comment source)
        {
            this.PostId = source.PostId;
            this.Name = source.Name;
            this.Email = source.Email;
            this.Body = source.Body;
        }
    }
}
