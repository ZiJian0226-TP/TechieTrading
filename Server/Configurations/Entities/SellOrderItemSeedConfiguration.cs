using System;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class SellOrderItemSeedConfiguration : IEntityTypeConfiguration<SellOrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SellOrderItem> builder)
        {
            builder.HasData(
                new SellOrderItem
                {
                    Id = 1,
                    Quantity = 5,
                    ProductId = 1,
                    SellOrderId = 1
                }
            );
        }
    }
}
