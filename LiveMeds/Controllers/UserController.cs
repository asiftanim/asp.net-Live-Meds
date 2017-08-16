using LiveMeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiveMeds.Controllers
{
    public class UserController : Controller
    {
        LiveMedsDBContex contex = new LiveMedsDBContex();

        // GET: User
        public ActionResult Index()
        {
            return View(contex.Users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            Users user = contex.Users.SingleOrDefault(e => e.userId == id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(Users user)
        {
            if(ModelState.IsValid)
            {
                contex.Users.Add(user);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            Users user = contex.Users.SingleOrDefault(e => e.userId == id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            if(ModelState.IsValid)
            {
                Users userToUpdate = contex.Users.SingleOrDefault(e => e.userId == user.userId);
                userToUpdate.Name = user.Name;
                userToUpdate.Password = user.Password;
                userToUpdate.Email = user.Email;
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            Users user = contex.Users.SingleOrDefault(e => e.userId == id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                Users user = contex.Users.SingleOrDefault(e => e.userId == id);
                contex.Users.Remove(user);
                contex.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
