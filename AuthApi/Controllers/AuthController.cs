﻿using AuthApi.Auth.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtTokenService _jwtTokenService;

    public AuthController(IJwtTokenService jwtTokenService)
    {
        _jwtTokenService = jwtTokenService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginModel user)
    {
        var loginResult = _jwtTokenService.GenerateAuthToken(user);

        return loginResult is null ? Unauthorized() : Ok(loginResult);
    }
}
