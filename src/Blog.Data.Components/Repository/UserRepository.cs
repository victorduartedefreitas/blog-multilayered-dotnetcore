using Blog.Data.Model;
using Blog.Data.Repository;
using System.Linq;

namespace Blog.Data.Components.Repository
{
    public class UserRepository : IUserRepository
    {
        public bool Delete(int userId)
        {
            if (!DbContext.Instance
                .Users
                .Any(f => f.UserId == userId))
                return false;

            return DbContext.Instance
                .Users
                .Remove(DbContext.Instance
                    .Users
                    .Single(f => f.UserId == userId));
        }

        public User GetUser(int userId)
        {
            return DbContext.Instance
                .Users
                .FirstOrDefault(f => f.UserId == userId);
        }

        public User GetUser(string email)
        {
            return DbContext.Instance
                .Users
                .FirstOrDefault(f => f.Email.Trim().ToUpper() == email.Trim().ToUpper());
        }

        public bool Save(User user)
        {
            if (user == null)
                return false;

            bool isNewRecord = !DbContext.Instance
                .Users
                .Any(f => f.UserId == user.UserId);

            if (isNewRecord)
            {
                user.UserId = DbContext.Instance
                    .Users
                    .OrderBy(f => f.UserId)
                    .Last()
                    .UserId + 1;

                DbContext.Instance
                    .Users
                    .Add(user);
            }
            else
            {
                var found = DbContext.Instance
                    .Users
                    .Single(f => f.UserId == user.UserId);

                found.CopyFrom(user);
            }

            return true;
        }
    }
}
