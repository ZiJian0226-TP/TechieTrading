using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class SellOrderSeedConfiguration : IEntityTypeConfiguration<SellOrder>
    {
        public void Configure(EntityTypeBuilder<SellOrder> builder)
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
