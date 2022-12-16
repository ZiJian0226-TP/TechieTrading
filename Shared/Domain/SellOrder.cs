using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechieTrading.Shared.Domain
{
    public class SellOrder : BaseDomainModel
    {
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeliveryType { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
