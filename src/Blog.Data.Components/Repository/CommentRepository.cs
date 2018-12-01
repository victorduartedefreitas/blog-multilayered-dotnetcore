using Blog.Data.Model;
using Blog.Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Components.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public bool Delete(int commentId)
        {
            if (!DbContext.Instance
                .Comments
                .Any(f => f.CommentId == commentId))
                return false;

            return DbContext.Instance
                .Comments
                .Remove(DbContext.Instance
                    .Comments
                    .Single(f => f.CommentId == commentId));
        }

        public Comment GetComment(int commentId)
        {
            return DbContext.Instance
                .Comments
                .FirstOrDefault(f => f.CommentId == commentId);
        }

        public IList<Comment> GetComments(int postId)
        {
            return DbContext.Instance
                .Comments
                .Where(f => f.PostId == postId)
                .ToList();
        }

        public IList<Comment> GetComments(string email)
        {
            return DbContext.Instance
                .Comments
                .Where(f => f.Email.Trim().ToUpper() == email.Trim().ToUpper())
                .ToList();
        }

        public bool Save(Comment comment)
        {
            if (comment == null)
                return false;

            bool isNewRecord = !DbContext.Instance
                .Comments
                .Any(f => f.CommentId == comment.CommentId);

            if (isNewRecord)
            {
                comment.CommentId = DbContext.Instance
                    .Comments
                    .OrderBy(f => f.CommentId)
                    .Last()
                    .CommentId + 1;

                DbContext.Instance
                    .Comments
                    .Add(comment);
            }
            else
            {
                var found = DbContext.Instance
                    .Comments
                    .Single(f => f.CommentId == comment.CommentId);

                found.CopyFrom(comment);
            }

            return true;
        }
    }
}
