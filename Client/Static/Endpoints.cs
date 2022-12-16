using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechieTrading.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string CustomerEndpoint = $"{Prefix}/Customer";
        public static readonly string ProductEndpoint = $"{Prefix}/Product";
        public static readonly string SellOrderEndpoint = $"{Prefix}/SellOrder";
        public static readonly string SellOrderItemEndpoint = $"{Prefix}/SellOrderItem";
        public static readonly string StaffEndpoint = $"{Prefix}/Staff";
        public static readonly string TradeOrderEndpoint = $"{Prefix}/TradeOrder";
        public static readonly string TradeOrderItemEndpoint = $"{Prefix}/TradeOrderItem";
    }
}
