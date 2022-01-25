using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SuperTraders.Core.DTOs;
using SuperTraders.Core.Entities;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Presentation.Controllers
{
    [Route("User")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        public UserController(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;
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

        [HttpPost("Buy")]
        [AllowAnonymous]
        public async Task<JsonResult> Buy([FromBody] OrderDto orderDto)
        {
            try
            {
                var userObject = HttpContext.Items["user"];
                if (userObject is User user)
                {
                    return new JsonResult(await _orderService.Buy(user, orderDto));
                }
                
                Response.StatusCode = 401;
                return new JsonResult("Unauthorized!");
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }

        [HttpPost("Sell")]
        [AllowAnonymous]
        public async Task<JsonResult> Sell([FromBody] OrderDto orderDto)
        {
            try
            {
                var userObject = HttpContext.Items["user"];
                if (userObject is User user)
                {
                    return new JsonResult(await _orderService.Sell(user, orderDto));
                }

                Response.StatusCode = 401;
                return new JsonResult("Unauthorized!");
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }
    }
}