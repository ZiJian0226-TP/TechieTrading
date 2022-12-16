using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieTrading.Shared.Domain
{
    public class TradeOrderItem : BaseDomainModel
    {
        public int Quantity { get; set; }
        public int TradeOrderId { get; set; }
        public virtual TradeOrder TradeOrder { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
