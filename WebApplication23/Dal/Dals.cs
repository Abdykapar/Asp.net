using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication23.Models;

namespace WebApplication23.Dal
{
    public class Dals:DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Homeland> Homeland { get; set; }

        public DbSet<Information> Information { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasMany<Homeland>(s => s.Homelands).WithRequired(s => s.Users).HasForeignKey(s => s.user_id);

            modelBuilder.Entity<Homeland>().ToTable("Homelands");
            modelBuilder.Entity<Homeland>().HasRequired<User>(s => s.Users).WithMany(s => s.Homelands).HasForeignKey(s => s.user_id);
            modelBuilder.Entity<Homeland>().HasMany<Information>(s => s.Informations).WithRequired(s => s.Homelands).HasForeignKey(s => s.homeland_id);

            modelBuilder.Entity<Information>().ToTable("Informations");
            modelBuilder.Entity<Information>().HasRequired<Homeland>(s => s.Homelands).WithMany(s => s.Informations).HasForeignKey(s => s.homeland_id);
        }
    }
}