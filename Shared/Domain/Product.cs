using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieTrading.Shared.Domain
{
    public class Product : BaseDomainModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public virtual List<TradeOrder> TradeOrder { get; set; }
        public virtual List<SellOrder> SellOrder { get; set; }
    }
}
