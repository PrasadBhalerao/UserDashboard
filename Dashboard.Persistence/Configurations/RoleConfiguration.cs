using Dashboard.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");

            builder.HasData
            (
                new Role
                {
                    KeyID = 1,
                    Name = "Admin"
                },
                new Role
                {
                    KeyID = 2,
                    Name = "Customer Executive"
                }
            );
        }
    }
}
