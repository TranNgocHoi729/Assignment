using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Dtos
{
    public class TokenResult
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool IsSuccess { get; set; }
    }
}
