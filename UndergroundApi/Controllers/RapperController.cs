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
    [Authorize(Roles ="Admin")]
    public IActionResult Delete(int id)
    {
        var shoeDeleted = _rapperRepository.DeleteRapper(id);

        return shoeDeleted ? NoContent() : NotFound();
    }
}