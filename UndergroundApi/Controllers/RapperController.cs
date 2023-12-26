using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UndergroundApi.Repositories;

namespace UndergroundApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RapperController : ControllerBase
{
    private readonly IRapperRepository _rapperRepository;

    public RapperController(IRapperRepository rapperRepository)
    {
        _rapperRepository = rapperRepository;
    }
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Get()
    {
        return Ok(_rapperRepository.GetRapper());
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult Delete(int id)
    {
        var result = _rapperRepository.DeleteRapper(id);

        return result ? NoContent() : NotFound();
    }
}