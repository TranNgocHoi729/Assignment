using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEGIDDO.Identity.Entities
{
    public class ListUser
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User
            {
                UId = Guid.NewGuid(),
                Password = "123456789",
                Username = "Admin1"
            },
            new User
            {
                UId = Guid.NewGuid(),
                Password = "123456789",
                Username = "Admin2"
            },
            new User
            {
                UId = Guid.NewGuid(),
                Password = "123456789",
                Username = "Admin3"
            }
        };
    }
}
