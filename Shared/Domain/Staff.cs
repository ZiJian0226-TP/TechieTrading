using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieTrading.Shared.Domain
{
    public class Staff : BaseDomainModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public virtual List<TradeOrder> TradeOrder { get; set; }
        public virtual List<SellOrder> SellOrder { get; set; }
    }
}
