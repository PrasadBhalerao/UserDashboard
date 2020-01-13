using Dashboard.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Persistence.Configurations
{
    public class StatusConfigurations : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasData
            (
                new Status
                {
                    KeyID = 1,
                    Name = "Active"
                },
                new Status
                {
                    KeyID = 2,
                    Name = "Pending"
                },
                new Status
                {
                    KeyID = 3,
                    Name = "Inactive"
                }
            );
        }
    }
}
