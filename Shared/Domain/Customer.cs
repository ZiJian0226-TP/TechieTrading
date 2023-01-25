using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechieTrading.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name does not meet length requirements")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name does not meet length requirements")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a vaild email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string Contact { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public List<TradeOrder> TradeOrder { get; set; }
        public List<SellOrder> SellOrder { get; set; }
    }
}
