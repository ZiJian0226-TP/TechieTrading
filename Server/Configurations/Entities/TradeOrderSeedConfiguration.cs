using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class TradeOrderSeedConfiguration : IEntityTypeConfiguration<TradeOrder>
    {
        public void Configure(EntityTypeBuilder<TradeOrder> builder)
        {
            builder.HasData(
                new TradeOrder
                {
                    Id = 1,
                    OrderDate = DateTime.Today,
                    OrderTime = DateTime.Now,
                    DeliveryType = "Store-Pick-Up",
                    StaffId = 1,
                    CustomerId = 1
                }
            );
        }
    }
}
