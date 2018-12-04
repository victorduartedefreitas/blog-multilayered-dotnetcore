using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Caching
{
    /// <summary>
    /// Cache em lista
    /// </summary>
    public class CacheDbContext
    {
        #region Locals

        private static CacheDbContext _instance;

        #endregion

        #region Constructors

        private CacheDbContext()
        {
            StartFakeDb();
        }

        #endregion

        #region Properties

        public static CacheDbContext Instance
        {
            get { return _instance ?? (_instance = new CacheDbContext()); }
        }

        public IList<User> Users { get; private set; }
        public IList<Post> Posts { get; private set; }
        public IList<Comment> Comments { get; private set; }

        #endregion

        #region Private Methods

        private void StartFakeDb()
        {
            Users = new List<User>();
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }

        #endregion
    }
}
