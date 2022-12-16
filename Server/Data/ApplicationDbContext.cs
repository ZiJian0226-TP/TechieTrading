using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TechieTrading.Server.Configurations.Entities;
using TechieTrading.Server.Models;
using TechieTrading.Shared.Domain;

namespace TechieTrading.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<SellOrder> SellOrder { get; set; }
        public DbSet<SellOrderItem> SellOrderItem { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<TradeOrder> TradeOrder { get; set; }
        public DbSet<TradeOrderItem> TradeOrderItem { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerSeedConfiguration());
            builder.ApplyConfiguration(new ProductSeedConfiguration());
            builder.ApplyConfiguration(new SellOrderSeedConfiguration());
            //builder.ApplyConfiguration(new SellOrderItemSeedConfiguration());
            builder.ApplyConfiguration(new StaffSeedConfiguration());
            builder.ApplyConfiguration(new TradeOrderSeedConfiguration());
            //builder.ApplyConfiguration(new TradeOrderItemSeedConfiguration());

            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }
    }
}
