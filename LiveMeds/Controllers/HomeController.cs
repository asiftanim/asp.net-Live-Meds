using LiveMeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveMeds.Controllers
{
    public class HomeController : Controller
    {
        LiveMedsDBContex contex = new LiveMedsDBContex();
        // GET: Home
        public ActionResult Index()
        {
            return View("Test", contex.Products.ToList());
        }
        public ActionResult Details(int id)
        {
            Product p = contex.Products.SingleOrDefault(e => e.productId == id);
            return View(p);
        }

        
    }
}