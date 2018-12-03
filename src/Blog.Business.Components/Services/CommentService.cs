using Blog.Business.Exceptions;
using Blog.Business.Model;
using Blog.Business.Services;
using Blog.Data.Model;
using Blog.Data.Repository;
using System;

namespace Blog.Business.Components.Services
{
    public class CommentService : ICommentService
    {
        #region Local Variables

        private ICommentRepository _commentRepository;

        #endregion

        #region Constructors

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        #endregion

        #region ICommentService Implementations

        public OperationResult CreateNewComment(Comment comment)
        {
            if (comment == null)
                throw new CommentException(CommentExceptionType.NullObject);
            else if (string.IsNullOrWhiteSpace(comment.Body))
                throw new CommentException(CommentExceptionType.NullBody);
            else if (comment.PostId <= 0)
                throw new CommentException(CommentExceptionType.NullPostId);
            else if (string.IsNullOrWhiteSpace(comment.Name))
                throw new CommentException(CommentExceptionType.NullName);
            else if (string.IsNullOrWhiteSpace(comment.Email))
                throw new CommentException(CommentExceptionType.NullEmail);
            else if (string.IsNullOrWhiteSpace(comment.Body))
                throw new CommentException(CommentExceptionType.NullBody);

            try
            {
                var result = _commentRepository.Save(comment);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new CommentException(CommentExceptionType.DefaultException, ex);
            }
        }

        public OperationResult DeleteComment(int commentId)
        {
            if (commentId <= 0)
                throw new CommentException(CommentExceptionType.NullCommentId);

            try
            {
                var result = _commentRepository.Delete(commentId);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new CommentException(CommentExceptionType.DefaultException, ex);
            }
        }

        public CommentOperationResult GetCommentsByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new CommentException(CommentExceptionType.NullEmail);

            try
            {
                var result = _commentRepository.GetComments(email);
                return new CommentOperationResult(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                throw new CommentException(CommentExceptionType.DefaultException, ex);
            }
        }

        public CommentOperationResult GetCommentsByPostId(int postId)
        {
            if (postId <= 0)
                throw new CommentException(CommentExceptionType.NullPostId);

            try
            {
                var result = _commentRepository.GetComments(postId);
                return new CommentOperationResult(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                throw new CommentException(CommentExceptionType.DefaultException, ex);
            }
        }

        public OperationResult UpdateComment(Comment comment)
        {
            if (comment == null)
                throw new CommentException(CommentExceptionType.NullObject);
            else if (string.IsNullOrWhiteSpace(comment.Body))
                throw new CommentException(CommentExceptionType.NullBody);
            else if (comment.PostId <= 0)
                throw new CommentException(CommentExceptionType.NullPostId);
            else if (string.IsNullOrWhiteSpace(comment.Name))
                throw new CommentException(CommentExceptionType.NullName);
            else if (string.IsNullOrWhiteSpace(comment.Email))
                throw new CommentException(CommentExceptionType.NullEmail);
            else if (string.IsNullOrWhiteSpace(comment.Body))
                throw new CommentException(CommentExceptionType.NullBody);

            try
            {
                var result = _commentRepository.Save(comment);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new CommentException(CommentExceptionType.DefaultException, ex);
            }
        }

        #endregion
    }
}
