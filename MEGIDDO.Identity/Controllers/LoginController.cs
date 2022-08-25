using MEGIDDO.Identity.Dtos;
using MEGIDDO.Identity.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Controllers
{
    [Route("Megiddo/Authentication")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMegiddo_Authentication _megiddoAuthen;

        public LoginController(IMegiddo_Authentication megiddoAuthen)
        {
            _megiddoAuthen = megiddoAuthen;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            var result = await _megiddoAuthen.GetJWTToken(user);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
