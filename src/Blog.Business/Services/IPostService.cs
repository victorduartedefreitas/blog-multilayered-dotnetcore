using Blog.Business.Model;
using Blog.Data.Model;
using System;

namespace Blog.Business.Services
{
    public interface IPostService
    {
        OperationResult CreateNewPost(Post post);
        OperationResult UpdatePost(Post post);
        PostOperationResult GetPostByPostId(int postId);
        PostOperationResult GetPosts(int userId, DateTimeOffset startDate);
        PostOperationResult GetLatestPosts(int page);
        OperationResult DeletePostByUserId(int postId);
    }
}
