using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTool.Models;

namespace InventoryTool.Controllers
{
    public class AcodesController : Controller
    {
        private InventoryToolContext db = new InventoryToolContext();

        // GET: Acodes
        public ActionResult Index()
        {
            return View(db.Atacodes.ToList());
        }

        // GET: Acodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acode acode = db.Atacodes.Find(id);
            if (acode == null)
            {
                return HttpNotFound();
            }
            return View(acode);
        }

        // GET: Acodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,code,Description")] Acode acode)
        {
            if (ModelState.IsValid)
            {
                db.Atacodes.Add(acode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acode);
        }

        // GET: Acodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acode acode = db.Atacodes.Find(id);
            if (acode == null)
            {
                return HttpNotFound();
            }
            return View(acode);
        }

        // POST: Acodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,code,Description")] Acode acode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acode);
        }

        // GET: Acodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acode acode = db.Atacodes.Find(id);
            if (acode == null)
            {
                return HttpNotFound();
            }
            return View(acode);
        }

        // POST: Acodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acode acode = db.Atacodes.Find(id);
            db.Atacodes.Remove(acode);
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
