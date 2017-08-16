using LiveMeds.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveMeds.Controllers
{
    
    public class ProductController : Controller
    {
        LiveMedsDBContex context = new LiveMedsDBContex();

        // GET: Product
        public ActionResult Index()
        {
            return View(context.Products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product p = context.Products.SingleOrDefault(e => e.productId == id);
            return View(p);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        public static String GetTimestamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p, HttpPostedFileBase ImagePath)
        {

            if (ModelState.IsValid)
         {
             string pic_name = p.Name + Path.GetExtension(ImagePath.FileName);
             string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic_name);

             ImagePath.SaveAs(path);
                
               // tyre.Url = filename;
                //p.ImagePath = DateTime.Now.ToLongDateString() + p.productId;
             p.ImagePath = "~/Images/" + pic_name;
                context.Products.Add(p);
                context.SaveChanges();
                return RedirectToAction("Index");
          }
         else
          {
          return View(p);
          }

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product p = context.Products.SingleOrDefault(e => e.productId == id);
            return View(p);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product p, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                Product pToUpdate = context.Products.SingleOrDefault(e => e.productId == p.productId);
                try
                {
                    string fullPath = Request.MapPath(p.ImagePath);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    string pic_name = p.Name + Path.GetExtension(ImagePath.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), pic_name);

                    ImagePath.SaveAs(path);

                    // tyre.Url = filename;
                    //p.ImagePath = DateTime.Now.ToLongDateString() + p.productId;
                    p.ImagePath = "~/Images/" + pic_name;
                    pToUpdate.ImagePath = p.ImagePath;

                }
                catch (Exception ex)
                { 
                
                }
               

                pToUpdate.Name = p.Name;
                pToUpdate.Description = p.Description;
                pToUpdate.Category = p.Category;
                pToUpdate.BuyingPrice = p.BuyingPrice;
                pToUpdate.SellingPrice = p.SellingPrice;
                pToUpdate.Quantity = p.Quantity;
                pToUpdate.Sold = p.Sold;
                pToUpdate.Formulation = p.Formulation;
                pToUpdate.Manufacturer = p.Manufacturer;
                pToUpdate.PackagingType = p.PackagingType;
                
                context.SaveChanges();

                return RedirectToAction("Index");
            }else
            {
                return View(p);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            Product p = context.Products.SingleOrDefault(e => e.productId == id);
            return View(p);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                Product p = context.Products.SingleOrDefault(e => e.productId == id);
                context.Products.Remove(p);
                string fullPath = Request.MapPath( p.ImagePath);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
