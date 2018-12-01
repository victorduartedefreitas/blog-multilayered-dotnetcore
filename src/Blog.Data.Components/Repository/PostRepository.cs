using Blog.Data.Model;
using Blog.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Components.Repository
{
    public class PostRepository : IPostRepository
    {
        public bool Delete(int postId)
        {
            if (!DbContext.Instance
                .Posts
                .Any(f => f.PostId == postId))
                return false;

            return DbContext.Instance
                .Posts
                .Remove(DbContext.Instance
                    .Posts
                    .Single(f => f.PostId == postId));
        }

        public IList<Post> GetLatestPosts(int skip, int limit)
        {
            return DbContext.Instance
                .Posts
                .OrderByDescending(f => f.CreationDate)
                .Skip(skip)
                .Take(limit)
                .ToList();
        }

        public Post GetPost(int postId)
        {
            return DbContext.Instance
                .Posts
                .FirstOrDefault(f => f.PostId == postId);
        }

        public IList<Post> GetPosts(int userId)
        {
            return DbContext.Instance
                .Posts
                .Where(f => f.UserId == userId)
                .ToList();
        }

        public IList<Post> GetPosts(DateTimeOffset startDate)
        {
            return DbContext.Instance
                .Posts
                .Where(f => f.CreationDate >= startDate)
                .ToList();
        }

        public IList<Post> GetPosts(int userId, DateTimeOffset startDate)
        {
            return DbContext.Instance
                .Posts
                .Where(f => f.UserId == userId && f.CreationDate >= startDate)
                .ToList();
        }

        public bool Save(Post post)
        {
            if (post == null)
                return false;

            bool isNewRecord = !DbContext.Instance
                .Posts
                .Any(f => f.PostId == post.PostId);

            if (isNewRecord)
            {
                if (DbContext.Instance.Posts.Count == 0)
                    post.PostId = 1;
                else
                    post.PostId = DbContext.Instance
                    .Posts
                    .OrderBy(f => f.PostId)
                    .Last()
                    .PostId + 1;

                DbContext.Instance
                    .Posts
                    .Add(post);
            }
            else
            {
                var found = DbContext.Instance
                    .Posts
                    .Single(f => f.PostId == post.PostId);

                found.CopyFrom(post);
            }

            return true;
        }
    }
}
