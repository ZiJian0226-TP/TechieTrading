using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Configurations.Entities
{
    public class SellOrderItemSeedConfiguration : IEntityTypeConfiguration<SellOrderItem>
    {
        public void Configure(EntityTypeBuilder<SellOrderItem> builder)
        {
            throw new NotImplementedException();
        }
    }
}
