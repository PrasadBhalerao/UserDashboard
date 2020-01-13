using Dashboard.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasData
            (
                new User
                {
                    KeyID = 1,
                    Name = "User 1",
                    Email = "user1@abc.com",
                    MobileNumber = "8181811818",
                    RoleId = 1,
                    StatusId = 1
                },
                new User
                {
                    KeyID = 2,
                    Name = "User 2",
                    Email = "user2@abc.com",
                    MobileNumber = "8181811818",
                    RoleId = 1,
                    StatusId = 2
                },
                new User
                {
                    KeyID = 3,
                    Name = "User 3",
                    Email = "user3@abc.com",
                    MobileNumber = "8181811818",
                    RoleId = 1,
                    StatusId = 3
                },
                new User
                {
                    KeyID = 4,
                    Name = "User 4",
                    Email = "user4@abc.com",
                    MobileNumber = "8181811818",
                    RoleId = 2,
                    StatusId = 1
                },
                new User
                {
                    KeyID = 5,
                    Name = "User 5",
                    Email = "user5@abc.com",
                    MobileNumber = "8181811818",
                    RoleId = 2,
                    StatusId = 2
                }
            );
        }
    }
}
