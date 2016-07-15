using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication23.Dal;
using WebApplication23.Models;

namespace WebApplication23.Controllers
{
    public class HomelandsController : Controller
    {
        private Dals db = new Dals();

        // GET: Homelands
        public ActionResult Index()
        {
            var homeland = db.Homeland.Include(h => h.Users);
            return View(homeland.ToList());
        }

        // GET: Homelands/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.Homeland.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            return View(homeland);
        }

        // GET: Homelands/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.User, "id", "Name");
            return View();
        }

        // POST: Homelands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,user_id")] Homeland homeland)
        {
            if (ModelState.IsValid)
            {
                db.Homeland.Add(homeland);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.User, "id", "Name", homeland.user_id);
            return View(homeland);
        }

        // GET: Homelands/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.Homeland.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.User, "id", "Name", homeland.user_id);
            return View(homeland);
        }

        // POST: Homelands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,user_id")] Homeland homeland)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeland).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.User, "id", "Name", homeland.user_id);
            return View(homeland);
        }

        // GET: Homelands/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Homeland homeland = db.Homeland.Find(id);
            if (homeland == null)
            {
                return HttpNotFound();
            }
            return View(homeland);
        }

        // POST: Homelands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Homeland homeland = db.Homeland.Find(id);
            db.Homeland.Remove(homeland);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
