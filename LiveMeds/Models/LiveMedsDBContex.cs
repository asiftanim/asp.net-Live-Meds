using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LiveMeds.Models
{
    public class LiveMedsDBContex : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivered> Delivered { get; set; }
    }
}