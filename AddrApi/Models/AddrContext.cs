using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddrApi.Models
{
    public class AddrContext : DbContext
    {
        public AddrContext(DbContextOptions<AddrContext> options)
            : base(options)
        {
        }

        public DbSet<AddrItem> AddrItems { get; set; }

    }
}