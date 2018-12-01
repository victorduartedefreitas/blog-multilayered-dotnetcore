using Blog.Data.Model;
using System;
using System.Collections.Generic;

namespace Blog.Data.Repository
{
    public interface IPostRepository
    {
        Post GetPost(int postId);
        IList<Post> GetPosts(int userId);
        IList<Post> GetPosts(DateTimeOffset startDate);
        IList<Post> GetPosts(int userId, DateTimeOffset startDate);
        IList<Post> GetLatestPosts(int skip, int limit);
        bool Save(Post post);
        bool Delete(int postId);
    }
}
