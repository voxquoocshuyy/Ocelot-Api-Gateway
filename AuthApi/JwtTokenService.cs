﻿using AuthApi.Auth.Models;
using JwtTokenAuthentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthApi.Entities;

namespace AuthApi;

public interface IJwtTokenService
{
    AuthenticationToken GenerateAuthToken(LoginModel loginModel);
}

public class JwtTokenService : IJwtTokenService
{
    private readonly OcelotUserContext _context;

    public JwtTokenService(OcelotUserContext context)
    {
        _context = context;
    }

    public AuthenticationToken GenerateAuthToken(LoginModel loginModel)
    {
        var user = _context.Users.FirstOrDefault(
            u => u.Name == loginModel.Username && u.Password == loginModel.Password);

        if (user is null)
        {
            throw new Exception("Invalid username or password.");
        }

        var role = _context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
        if (role is null)
        {
            throw new Exception("Invalid role of user.");
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtExtensions.SecurityKey));
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var expirationTimeStamp = DateTime.Now.AddMinutes(5);


        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, user.Name),
            new Claim("role", role.Name),
            new Claim("scope", string.Join(" ", user.Scopes))
        };

        var tokenOptions = new JwtSecurityToken(
            issuer: "https://localhost:5002",
            claims: claims,
            expires: expirationTimeStamp,
            signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return new AuthenticationToken(tokenString, (int)expirationTimeStamp.Subtract(DateTime.Now).TotalSeconds);
    }
}