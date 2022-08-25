using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Client.Model
{
    public class TokenDto
    {
        public string token { get; set; }

        public string refreshToken { get; set; }

        public bool isSuccess { get; set; }
    }
}
