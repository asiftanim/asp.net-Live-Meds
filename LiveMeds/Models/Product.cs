using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LiveMeds.Models
{
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int BuyingPrice { get; set; }

        [Required]
        public int SellingPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Sold { get; set; }

      //  [Required]
        public string ImagePath { get; set; }
        
        [Required]
        public string Formulation { get; set; }
       
        [Required]
        public string Manufacturer { get; set; }
       
        [Required]
        public string PackagingType { get; set; }
        public List<Order> Orders { get; set; }
       

    }
}