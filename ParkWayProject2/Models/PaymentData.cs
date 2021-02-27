using System.ComponentModel.DataAnnotations;

namespace ParkWayProject2.Models
{
    public class PaymentData
    {
        [Display(Name = "Minimum Amount")]
        public decimal minAmount { get; set; }
        [Display(Name = "Maximum Amount")]
        public decimal maxAmount { get; set; }
        [Display(Name = "Charge Fee =>")]
        public decimal feeAmount { get; set; }
        [Display(Name = "Total Amount =>")]
        public decimal totalAmount { get; set; }
        [Display(Name = "Transfer Amount =>")]
        public decimal transferAmount { get; set; }

        
    }
}
