using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProject2.Models
{
    public class PaymentDataViewModel
    {
        public decimal minAmount { get; set; }
        public decimal maxAmount { get; set; }
        public decimal feeAmount { get; set; }

        public decimal totalAmount { get; set; }

        public decimal transferAmount { get; set; }
    }
}
