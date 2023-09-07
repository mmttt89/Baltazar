using System;
using Microsoft.AspNetCore.Identity;

namespace Baltazar.Entity.Entities
{
	public class ApplicationUser : IdentityUser
	{

        public ICollection<Order>? Orders { get; set; }
    }
}

