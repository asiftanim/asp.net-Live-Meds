using LiveMeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveMeds.Controllers
{
    public class AdminController : Controller
    {
        LiveMedsDBContex context = new LiveMedsDBContex();
        // GET: Admin
        public ActionResult Index()
        {
            return View(context.Admins.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            Admin admin = context.Admins.SingleOrDefault(e => e.AdminId == id);
            return View(admin);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Admin admin)
        {
            if(ModelState.IsValid)
            {
                context.Admins.Add(admin);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(admin);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            Admin admin = context.Admins.SingleOrDefault(e => e.AdminId == id);
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin admin)
        {
            if(ModelState.IsValid)
            {
                Admin adminToUpdate = context.Admins.SingleOrDefault(e => e.AdminId == admin.AdminId);
                adminToUpdate.Name = admin.Name;
                adminToUpdate.Email = admin.Email;
                adminToUpdate.Password = admin.Password;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(admin);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            Admin admin = context.Admins.SingleOrDefault(e => e.AdminId == id);
            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Admin admin = context.Admins.SingleOrDefault(e => e.AdminId == id);
                context.Admins.Remove(admin);
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
