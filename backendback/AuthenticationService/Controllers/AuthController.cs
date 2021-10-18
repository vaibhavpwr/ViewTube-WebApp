using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AuthenticationService.Exceptions;
using AuthenticationService.Models;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
namespace AuthenticationService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(User user)
        {
            try
            {
                bool flag = _authService.RegisterUser(user);
                return Created("", flag);
            }
            catch (UserAlreadyExistsException e)
            {
                return Conflict(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("login")]
        [ActionName("Post")]
        public IActionResult Login(User user)
        {
            try
            {
                bool flag = _authService.LoginUser(user);
                if (flag == true)
                {
                    string token = generateToken(user);
                    return Ok(token);
                }
                else throw new UnauthorizedAccessException("Invalid user id or password");
            }
            catch (UnauthorizedAccessException e)
            {
                return Unauthorized(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost("isAuthenticated")]
        [ActionName("Post")]
        public IActionResult ValidateJwtToken()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ThisismySecretKey");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = "Authapi",
                    ValidAudience = "AuthClients",
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);
                return Ok(true);
            }
            catch
            {

                return Ok(false);
            }
        }
        string generateToken(User user)
        {
            var claim = new[] { new Claim("userId", user.UserId) };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var signature = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "Authapi",
                audience: "AuthClients",
                expires: DateTime.Now.AddMinutes(30),
                claims: claim,
                signingCredentials: signature);

            var createdToken = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return JsonConvert.SerializeObject(createdToken);
        }
    }

}
