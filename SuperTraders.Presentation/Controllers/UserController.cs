using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SuperTraders.Core.DTOs;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Presentation.Controllers
{
    [Route("User")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost()]
        [AllowAnonymous]
        public async Task<JsonResult> Add([FromBody] SignUpDto signUpDto)
        {
            try
            {
                return new JsonResult(await _userService.Create(signUpDto));
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }
    }
}
