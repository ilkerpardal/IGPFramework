using IgpFramework.Data.Model.Menus;
using IgpFramework.Data.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace IgpFramework.Data
{
    public class IGPCoreContext : DbContext
    {
        IConfiguration _configuration = null;
        
        public IGPCoreContext(DbContextOptions<IGPCoreContext> options, IConfiguration configuration) : base(options) 
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("sqlConnection"));
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
