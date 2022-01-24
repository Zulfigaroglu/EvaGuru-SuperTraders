using System;
using System.Threading.Tasks;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;
using SuperTraders.Services.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SuperTraders.Presentation.Controllers
{
    [Route("Auth")]
    [EnableCors("MyPolicy")]
    public class AuthController: ControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<JsonResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                return new JsonResult(await _userService.Login(loginDto));
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }
    

        [HttpPost("Logout")]
        public async Task<JsonResult> Logout()
        {
            try
            {
                User? user = (User?)Request.HttpContext.Items["user"];
                if (user != null)
                {
                    await _userService.Logout(user);
                    return new JsonResult(true);
                }
                else
                {
                    return new JsonResult(false);
                }
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }
    }
}