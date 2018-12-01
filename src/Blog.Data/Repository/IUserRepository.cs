namespace Blog.Data.Repository
{
    public interface IUserRepository
    {
        Model.User GetUser(int userId);
        Model.User GetUser(string email);
        bool Save(Model.User user);
        bool Delete(int userId);
    }
}
