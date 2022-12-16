using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechieTrading.Server.Models;

namespace TechieTrading.Server.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
            new ApplicationUser
            {
                Id = "LocalStaff",
                Email = "staff@localhost.com",
                NormalizedEmail = "STAFF@LOCALHOST.COM",
                FirstName = "Staff",
                LastName = "Admin",
                UserName = "Staff",
                NormalizedUserName = "STAFF",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            },
            new ApplicationUser
            {
                Id = "GuestCustomer",
                Email = "guest@localhost.com",
                NormalizedEmail = "GUEST@LOCALHOST.COM",
                FirstName = "Guest",
                LastName = "Customer",
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                PasswordHash = hasher.HashPassword(null, "P@ssword1")
            }
            );
        }
    }
}
