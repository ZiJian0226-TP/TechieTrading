using System;
using System.Threading.Tasks;
using TechieTrading.Shared.Domain;
using Microsoft.AspNetCore.Http;

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