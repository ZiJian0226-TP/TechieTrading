using System;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "ZiJian",
                    LastName = "Pang",
                    Gender = "Male",
                    Email = "2003980F@student.tp.edu.sg",
                    Contact = "96369464",
                    DateOfBirth = new DateTime(1999, 2, 26),
                    Address = "465 Tampines St 44, 520465 Singapore",
                }
            );
        }
    }
}
