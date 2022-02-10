using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Printing_Photo_Online;

namespace Printing_Photo_Online.Controllers
{
    public class categoriesController : Controller
    {
        private Digital_Photo_PrintEntities db = new Digital_Photo_PrintEntities();

        // GET: categories
        public ActionResult Index()
        {
            if (Session["name"] != null)
            {
                return View(db.categories.ToList());
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // GET: categories/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["name"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                category category = db.categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }            
            return View();
        }

        // GET: categories/Create
        public ActionResult Create()
        {
            if (Session["name"] != null)
            {
                return View();
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // POST: categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Category_Name")] category category)
        {
            if (ModelState.IsValid)
            {
                db.categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["name"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                category category = db.categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Category_Name")] category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["name"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                category category = db.categories.Find(id);
                if (category == null)
                {
                    return HttpNotFound();
                }
                return View(category);
            }
            else if (Session["name"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // POST: categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            category category = db.categories.Find(id);
            db.categories.Remove(category);
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
