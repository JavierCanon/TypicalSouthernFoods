using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TypicalSouthernFoods.Web.Persistence;

namespace TypicalSouthernFoods.Web.Controllers
{
    public class CLIENTsController : Controller
    {
        private EntitiesDataModel db = new EntitiesDataModel();

        // GET: CLIENTs
        public ActionResult Index()
        {
            return View(db.CLIENTS.ToList());
        }

        // GET: CLIENTs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTS.Find(id);
            if (cLIENT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT);
        }

        // GET: CLIENTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CLIENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAMES,SURNAMES,ADDRESS,PHONE")] CLIENT cLIENT)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTS.Add(cLIENT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLIENT);
        }

        // GET: CLIENTs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTS.Find(id);
            if (cLIENT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT);
        }

        // POST: CLIENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAMES,SURNAMES,ADDRESS,PHONE")] CLIENT cLIENT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLIENT);
        }

        // GET: CLIENTs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT cLIENT = db.CLIENTS.Find(id);
            if (cLIENT == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT);
        }

        // POST: CLIENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CLIENT cLIENT = db.CLIENTS.Find(id);
            db.CLIENTS.Remove(cLIENT);
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
