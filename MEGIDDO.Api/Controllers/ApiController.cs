using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Api.Controllers
{
    [Route("api/listUser")]
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        [HttpGet("user")]
        public async Task<IActionResult> GetListUser()
        {
            List<string> Users = new List<string>
            {
                "Hoi", "Tuan","Yasuo"
            };
            return Ok(Users);
        }
    }
}
