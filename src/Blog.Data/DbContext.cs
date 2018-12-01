using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Data
{
    /// <summary>
    /// Banco de dados Fake
    /// </summary>
    public class DbContext
    {
        #region Locals

        private static  DbContext _instance;

        #endregion

        #region Constructors

        private DbContext()
        {
            StartFakeDb();
        }

        #endregion

        #region Properties

        public static DbContext Instance
        {
            get { return _instance ?? (_instance = new DbContext()); }
        }

        public IList<User> Users { get; private set; }
        public IList<Post> Posts { get; private set; }
        public IList<Comment> Comments { get; private set; }

        #endregion

        #region Private Methods

        private void StartFakeDb()
        {
            Users = ConfigFakeDb.InitUsers();
            Posts = ConfigFakeDb.InitPosts();
            Comments = ConfigFakeDb.InitComments();
        }

        #endregion
    }
}
