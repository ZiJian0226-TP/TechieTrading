using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechieTrading.Shared.Domain
{
    public class SellOrder : BaseDomainModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public DateTime OrderTime { get; set; }
        public string DeliveryType { get; set; }
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public List<SellOrderItem> SellOrderItem { get; set; }
    }
}
