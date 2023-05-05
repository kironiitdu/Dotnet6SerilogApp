using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Notnet6Identity.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Notnet6IdentityUser class
public class Notnet6IdentityUser : IdentityUser
{
    public string Name { get; set; } // Added this new column to the ApplicationUser model.

    public string UserName { get; set; }

    public override string Email { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}

