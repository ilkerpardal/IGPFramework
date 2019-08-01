using IgpFramework.Data.Model.Menus;
using IgpFramework.Data.Model.Users;
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

        public DbSet<User> User { get; set; }
        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<UserMenu> UserMenu { get; set; }
        public DbSet<UserSession> UserSession { get; set; }

    }
}
