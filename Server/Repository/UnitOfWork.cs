using TechieTrading.Server.Data;
using TechieTrading.Server.IRepository;
using TechieTrading.Server.Models;
using TechieTrading.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TechieTrading.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Product> _products;
        private IGenericRepository<SellOrder> _sellorders;
        private IGenericRepository<SellOrderItem> _sellorderitems;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<TradeOrder> _tradeorders;
        private IGenericRepository<TradeOrderItem> _tradeorderitems;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Product> Products
            => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<SellOrder> SellOrders
            => _sellorders ??= new GenericRepository<SellOrder>(_context);
        public IGenericRepository<SellOrderItem> SellOrderItems
            => _sellorderitems ??= new GenericRepository<SellOrderItem>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<TradeOrder> TradeOrders
            => _tradeorders ??= new GenericRepository<TradeOrder>(_context);
        public IGenericRepository<TradeOrderItem> TradeOrderItems
            => _tradeorderitems ??= new GenericRepository<TradeOrderItem>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            /*foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }*/

            await _context.SaveChangesAsync();
        }
    }
}