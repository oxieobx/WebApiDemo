using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.DBO.Entities
{
   public class AppRole : IdentityUser<Guid>
    {
        public string Description { get; set; }
        public string UserDetails { get; set; }
    }
}
