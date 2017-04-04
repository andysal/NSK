using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nsk.BackRoom.Web.Models.Product
{
    public class CreateViewModel
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int QuantityPerUnit { get; set; }
    }
}