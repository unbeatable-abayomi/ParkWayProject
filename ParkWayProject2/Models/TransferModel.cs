using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWayProject2.Models
{
    public class TransferModel
    {
        [Display(Name = "Enter Your Transfer Amount")]
        public decimal TransferAmount { get; set; }
    }
}
