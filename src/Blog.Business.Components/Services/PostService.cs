using Blog.Business.Exceptions;
using Blog.Business.Model;
using Blog.Business.Services;
using Blog.Data.Model;
using Blog.Data.Repository;
using System;
using System.Collections.Generic;

namespace Blog.Business.Components.Services
{
    public class PostService : IPostService
    {
        #region Local Variables

        IPostRepository _postRepository;

        #endregion

        #region Constructors

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        #endregion

        #region IPostService Implementations

        public OperationResult CreateNewPost(Post post)
        {
            if (post == null)
                throw new PostException(PostExceptionType.NullObject);
            else if (post.UserId <= 0)
                throw new PostException(PostExceptionType.NullUserId);
            else if (string.IsNullOrWhiteSpace(post.Title))
                throw new PostException(PostExceptionType.NullTitle);
            else if (string.IsNullOrWhiteSpace(post.Body))
                throw new PostException(PostExceptionType.NullBody);

            try
            {
                var result = _postRepository.Save(post);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        public OperationResult DeletePostByUserId(int postId)
        {
            if (postId <= 0)
                throw new PostException(PostExceptionType.NullPostId);

            try
            {
                var result = _postRepository.Delete(postId);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        public PostOperationResult GetLatestPosts(int page)
        {
            if (page <= 0)
                throw new PostException(PostExceptionType.NullPage);

            int limit = 1,
                skip = limit * (page - 1);

            try
            {
                var result = _postRepository.GetLatestPosts(skip, limit);
                return new PostOperationResult(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        public PostOperationResult GetPostByPostId(int postId)
        {
            if (postId <= 0)
                throw new PostException(PostExceptionType.NullPostId);

            try
            {
                var resultList = new List<Post>();
                var post = _postRepository.GetPost(postId);
                if (post != null)
                    resultList.Add(post);

                return new PostOperationResult(true, string.Empty, resultList);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        public PostOperationResult GetPosts(int userId, DateTimeOffset startDate)
        {
            if (userId <= 0)
                throw new PostException(PostExceptionType.NullUserId);
            if (startDate == null)
                startDate = new DateTimeOffset();

            try
            {
                var result = _postRepository.GetPosts(userId, startDate);
                return new PostOperationResult(true, string.Empty, result);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        public OperationResult UpdatePost(Post post)
        {
            if (post == null)
                throw new PostException(PostExceptionType.NullObject);
            else if (post.UserId <= 0)
                throw new PostException(PostExceptionType.NullUserId);
            else if (string.IsNullOrWhiteSpace(post.Title))
                throw new PostException(PostExceptionType.NullTitle);
            else if (string.IsNullOrWhiteSpace(post.Body))
                throw new PostException(PostExceptionType.NullBody);

            try
            {
                var result = _postRepository.Save(post);
                return new OperationResult(result, string.Empty);
            }
            catch (Exception ex)
            {
                throw new PostException(PostExceptionType.DefaultException, ex);
            }
        }

        #endregion
    }
}
