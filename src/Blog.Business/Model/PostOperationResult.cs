using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Business.Model
{
    public class PostOperationResult : OperationResult
    {
        public PostOperationResult(bool success, string message, IList<Post> posts)
            : base(success, message)
        {
            if (posts == null)
                posts = new List<Post>();

            Posts = posts;
        }

        public IList<Post> Posts { get; set; }
    }
}
