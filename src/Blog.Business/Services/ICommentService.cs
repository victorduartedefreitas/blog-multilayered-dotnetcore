using Blog.Business.Model;
using Blog.Data.Model;

namespace Blog.Business.Services
{
    public interface ICommentService
    {
        OperationResult CreateNewComment(Comment comment);
        OperationResult UpdateComment(Comment comment);
        CommentOperationResult GetCommentsByPostId(int postId);
        CommentOperationResult GetCommentsByEmail(string email);
        OperationResult DeleteComment(int commentId);
    }
}
