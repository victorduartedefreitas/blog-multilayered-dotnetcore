using Blog.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Web.Cache
{
    public class CacheDbContext
    {
        #region Locals

        private static CacheDbContext _instance;

        #endregion

        #region Constructors

        private CacheDbContext()
        {
            Posts = new List<PostDTO>();
        }

        #endregion

        #region Properties

        public static CacheDbContext Instance
        {
            get { return _instance ?? (_instance = new CacheDbContext()); }
        }

        public IList<PostDTO> Posts { get; private set; }

        #endregion

        #region Public Methods

        public void AddPostsToCache(IList<PostDTO> posts)
        {
            foreach (var p in posts)
            {
                if (!Posts.Any(f => f.PostId == p.PostId))
                    Posts.Add(p);
            }
        }

        #endregion
    }
}
