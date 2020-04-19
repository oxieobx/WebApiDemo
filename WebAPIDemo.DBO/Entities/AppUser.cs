using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.DBO.Entities
{
    public class AppUser : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
