using System;
using Microsoft.AspNetCore.Identity;

namespace DAL.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

