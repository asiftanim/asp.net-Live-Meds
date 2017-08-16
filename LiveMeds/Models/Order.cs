using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LiveMeds.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public string productName { get; set; }

        [Required]
        public int productQuantity { get; set; }

        [Required]
        public int unitPrice { get; set; }

        [Required]
        public string orderTime { get; set; }
        [Required]
        public Users User { get; set; }
        [Required]
        public List<Product> Products { get; set; }
    }
}