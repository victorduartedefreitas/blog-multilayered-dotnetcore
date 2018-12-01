using Blog.Data.Model;

namespace Blog.Business.Model
{
    public class UserOperationResult : OperationResult
    {
        public UserOperationResult(bool success, string message, User user)
            : base(success, message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
