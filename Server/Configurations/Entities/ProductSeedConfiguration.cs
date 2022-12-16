using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
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
