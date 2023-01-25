using System;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class SellOrderSeedConfiguration : IEntityTypeConfiguration<SellOrder>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SellOrder> builder)
        {
            builder.HasData(
                new SellOrder
                {
                    Id = 1,
                    OrderDate = DateTime.Today,
                    OrderTime = DateTime.Now,
                    DeliveryType = "Standard-Shipping",
                    StaffId = 1,
                    CustomerId = 1
                }
            );
        }
    }
}
