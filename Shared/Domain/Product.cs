using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechieTrading.Shared.Domain
{
    public class Product : BaseDomainModel 
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public List<TradeOrderItem> TradeOrderItem { get; set; }
        public List<SellOrderItem> SellOrderItem { get; set; }
    }
}
