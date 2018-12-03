using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Business.Model
{
    public class CommentOperationResult : OperationResult
    {
        public CommentOperationResult(bool success, string message, IList<Comment> comments)
            : base(success, message)
        {
            if (comments == null)
                comments = new List<Comment>();

            Comments = comments;
        }

        public IList<Comment> Comments { get; set; }
    }
}
