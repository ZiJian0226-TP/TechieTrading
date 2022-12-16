using TechieTrading.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechieTrading.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<SellOrder> SellOrders { get; }
        IGenericRepository<SellOrderItem> SellOrderItems { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<TradeOrder> TradeOrders { get; }
        IGenericRepository<TradeOrderItem> TradeOrderItems { get; }
    }
}