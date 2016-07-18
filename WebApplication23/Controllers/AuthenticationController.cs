using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication23.Dal;
using WebApplication23.Models;


namespace WebApplication20.Controllers
{
    public class AuthenticationController : Controller
    {
        private Dals db = new Dals();
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult DoLogin(User u)
        {
            Dals _odal = new Dals();
            User user = new User();

            user = (from frm in _odal.User.ToList() where frm.email == u.email && frm.Parola == u.Parola select frm).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "Users");
            }
            else
                return View("Login");
        }

        [HttpGet]
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "id,Name,Surname,Parola,email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Main");
            }
            
            return View(user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}