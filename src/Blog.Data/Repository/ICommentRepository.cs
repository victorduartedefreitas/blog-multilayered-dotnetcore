using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Data.Repository
{
    public interface ICommentRepository
    {
        Comment GetComment(int commentId);
        IList<Comment> GetComments(int postId);
        IList<Comment> GetComments(string email);
        bool Save(Comment comment);
        bool Delete(int commentId);
    }
}
