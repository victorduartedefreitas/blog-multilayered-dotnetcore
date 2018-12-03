using Blog.Business.Model;
using Blog.Data.Model;

namespace Blog.Business.Services
{
    public interface IUserService
    {
        OperationResult CreateNewUser(User user);
        OperationResult UpdateUser(User user);
        UserOperationResult GetUserByEmail(string email);
        UserOperationResult GetUserByUserId(int userId);
        OperationResult DeleteUserByUserId(int userId);
        OperationResult DeleteUserByEmail(string email);
    }
}
