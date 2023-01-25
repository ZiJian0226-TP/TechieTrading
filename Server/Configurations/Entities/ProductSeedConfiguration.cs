using System;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Razer Viper Mini Mouse",
                    Description = "8500 DPI",
                    Type = "Accessory",
                    Quantity = 60,
                    Price = 30.00,
                    ManufactureDate = new DateTime(2021,11,30)
                }
            );
        }
    }
}
