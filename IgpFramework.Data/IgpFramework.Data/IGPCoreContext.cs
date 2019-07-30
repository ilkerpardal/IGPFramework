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

        public DbSet<Users.User> Users { get; set; }

    }
}
