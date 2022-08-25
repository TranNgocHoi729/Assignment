using MEGIDDO.Identity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Repositories
{
    public interface IMegiddo_Authentication
    {
        Task<TokenResult> GetJWTToken(UserLoginModel user);
    }
}
