using Microsoft.EntityFrameworkCore;
using System;

namespace IgpFramework.Data
{
    public class IGPCoreContext : DbContext
    {

        public IGPCoreContext(DbContextOptions<IGPCoreContext> options) : base(options) 
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Users.User> User { get; set; }
        public DbSet<Users.UserPassword> UserPassword { get; set; }
        public DbSet<Menus.Menu> Menu { get; set; }
        public DbSet<Users.UserMenu> UserMenu { get; set; }
        public DbSet<Users.UserSession> UserSession { get; set; }

    }
}
