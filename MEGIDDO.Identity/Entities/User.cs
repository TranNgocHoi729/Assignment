using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Entities
{
    public class User
    {
        public Guid UId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
