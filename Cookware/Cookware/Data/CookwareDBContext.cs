using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cookware.Data
{
    public class CookwareDBContext : DbContext
    {
        public CookwareDBContext(DbContextOptions<CookwareDBContext> options) : base(options)
        {

        }

    }
}
