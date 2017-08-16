using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LiveMeds.Models
{
    public class Delivered
    {
        [Key]
        public int deliverId { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public string orderTime { get; set; }

        [Required]
        public string deliverTime { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public string productName { get; set; }

        [Required]
        public int productQuantity { get; set; }

        [Required]
        public string productUnitPrice { get; set; }
    }
}