using AuthApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Repositories.UserRepo;

public class UserRepo : IUserRepo
{
    private readonly OcelotUserContext _context;
    private readonly ILogger<UserRepo> _logger;

    public UserRepo(OcelotUserContext context, ILogger<UserRepo> logger)
    {
        _context = context;
        _logger = logger;
    }

    public List<User> GetUser()
    {
        try
        {
            _logger.LogInformation($"Get rapper: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            var user = _context.Users.Include(u => u.Role).ToList();
            return user;
        }
        catch (Exception e)
        {
            _logger.LogError($"Error: {e.Message}");
            throw;
        }
    }

    public bool DeleteUser(int id)
    {
        var rapper = _context.Users.FirstOrDefault(x => x.Id == id);
        if (rapper == null)
            return false;
        _context.Users.Remove(rapper);
        _context.SaveChanges();
        return true;
    }
}