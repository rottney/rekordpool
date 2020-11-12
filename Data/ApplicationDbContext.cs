using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Toolbelt.ComponentModel.DataAnnotations;

namespace Rekordpool.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<Rekordpool.Models.Track> Track { get; set; }
    }
}
