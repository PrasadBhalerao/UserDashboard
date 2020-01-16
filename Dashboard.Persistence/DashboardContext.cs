using Dashboard.Persistence.Configurations;
using Dashboard.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dashboard.Persistence
{
    public class DashboardContext : DbContext
    {
        public DashboardContext()
        {

        }
        public DashboardContext(DbContextOptions options) : base (options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfigurations());
            modelBuilder.ApplyConfiguration(new UserConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
