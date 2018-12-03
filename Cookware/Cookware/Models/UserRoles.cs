using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Models
{
    /// <summary>
    /// These roles are used to enact user policies
    /// </summary>
    public class UserRoles : IdentityUser 
    {
        public const string Member = "Member";
        public const string Admin = "Administrator";
    }
}
