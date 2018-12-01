using Blog.Data.Model;
using System.Collections.Generic;

namespace Blog.Data
{
    public static class ConfigFakeDb
    {
        public static IList<User> InitUsers()
        {
            return new List<User>();
        }

        public static IList<Post> InitPosts()
        {
            return new List<Post>();
        }

        public static IList<Comment> InitComments()
        {
            return new List<Comment>();
        }
    }
}
