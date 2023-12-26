using AuthApi.Entities;

namespace AuthApi.Repositories.UserRepo;

public interface IUserRepo
{
    List<User> GetUser();

    bool DeleteUser(int id);
}