using Microsoft.EntityFrameworkCore;
using System;

namespace IgpFramework.Data
{
    public class IGPCoreContext : DbContext
    {
        public DbSet<Users.User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
