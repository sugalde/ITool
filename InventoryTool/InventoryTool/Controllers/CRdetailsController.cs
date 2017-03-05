using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTool.Models;
using InventoryTool.ViewModels;

namespace InventoryTool.Controllers
{
    public class CRdetailsController : Controller
    {
        private InventoryToolContext db = new InventoryToolContext();

        // GET: CRdetails
        public ActionResult Index()
        {
            return View(db.CRdetails.ToList());
        }

        // GET: CRdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRdetail cRdetail = db.CRdetails.Find(id);
            if (cRdetail == null)
            {
                return HttpNotFound();
            }
            return View(cRdetail);
        }

        // GET: CRdetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CRdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(newCR newcr, int screen)
        {
            CRdetail detail = newcr.crdetail;
            var atacode = from s in db.Atacodes
                          where s.code.ToString().Contains(detail.Atacode.ToString())
                          select s;
            detail.CreateDate = DateTime.Now;
            detail.CreatedBy = Environment.UserName;
            detail.Description = atacode.ToList()[0].Description;
            if (ModelState.IsValid)
            {
                db.CRdetails.Add(detail);
                db.SaveChanges();
                if (screen == 2)
                { return RedirectToAction("Edit", "CRs", new { id = detail.IDCR }); }
                else { return RedirectToAction("Create", "CRs", new { id = detail.IDCR }); }
            }

            return View(detail);
        }

        // GET: CRdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRdetail cRdetail = db.CRdetails.Find(id);
            if (cRdetail == null)
            {
                return HttpNotFound();
            }
            return View(cRdetail);
        }

        // POST: CRdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDCR,Quantity,Atacode,Description,Requested,Authorized,Paymentdate,CreatedBy")] CRdetail cRdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cRdetail);
        }

        // GET: CRdetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRdetail cRdetail = db.CRdetails.Find(id);
            if (cRdetail == null)
            {
                return HttpNotFound();
            }
            return View(cRdetail);
        }

        // POST: CRdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRdetail cRdetail = db.CRdetails.Find(id);
            db.CRdetails.Remove(cRdetail);
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
