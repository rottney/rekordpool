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

        // Tried to use to enforce unique artist/track,
        // but only runs at startup
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rekordpool.Models.Track>()
                .HasIndex(t => new { t.ArtistName, t.Title })
                .IsUnique(true);
            
            Console.WriteLine("made it her");

            //modelBuilder.BuildIndexesFromAnnotations();
        }*/
    }
}
