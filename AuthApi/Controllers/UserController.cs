using AuthApi.Repositories.UserRepo;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;

    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    [HttpGet]
    public IActionResult GetUser()
    {
        var result = _userRepo.GetUser();

        return Ok(result);
    }
}