using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SuperTraders.Core.DTOs;
using SuperTraders.Services.Infrastructure;

namespace SuperTraders.Presentation.Controllers
{
    [Route("Share")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private readonly IShareService _shareService;

        public ShareController(IShareService shareService)
        {
            this._shareService = shareService;
        }
        
        [HttpGet()]
        public async Task<JsonResult> All()
        {
            try
            {
                return new JsonResult(await this._shareService.All());
            }
            catch (Exception exception)
            {
                Response.StatusCode = 500;
                return new JsonResult(exception.Message);
            }
        }
    }
}
