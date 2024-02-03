using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "JiaJun",
                    LastName = "Ang",
                    Gender = "Male",
                    Email = "2100867G@student.tp.edu.sg",
                    Contact = "87977031"
                }
            );
        }
    }
}
