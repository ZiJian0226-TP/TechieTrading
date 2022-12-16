using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieTrading.Shared.Domain
{
    public class SellOrderItem : BaseDomainModel
    {
        public int Quantity { get; set; }
        public int SellOrderId { get; set; }
        public virtual SellOrder SellOrder { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
