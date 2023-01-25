using System;
using Microsoft.EntityFrameworkCore;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class TradeOrderItemSeedConfiguration : IEntityTypeConfiguration<TradeOrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TradeOrderItem> builder)
        {
            builder.HasData(
                new TradeOrderItem
                {
                    Id = 1,
                    Quantity = 5,
                    ProductId = 1,
                    TradeOrderId = 1
                }
            );
        }
    }
}
