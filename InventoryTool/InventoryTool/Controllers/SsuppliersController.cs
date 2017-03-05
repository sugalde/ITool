using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryTool.Models;
using PagedList;

namespace InventoryTool.Controllers
{
    public class SsuppliersController : Controller
    {
        private InventoryToolContext db = new InventoryToolContext();

        // GET: Ssuppliers
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, int? id, int? screen)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Supplier Name" : "";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "Telephone/fax/email" : "";
            ViewBag.ObligorSortParm = String.IsNullOrEmpty(sortOrder) ? "ZIP Code" : "";
            ViewBag.cr = id;
            ViewBag.screen = screen;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var suppliers = from s in db.Suppliers
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                suppliers = suppliers.Where(s => s.SupplierName.ToString().Contains(searchString)
                                       || s.Telephonefaxemail.ToString().Contains(searchString)
                                       || s.ZIPCode.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Supplier Name":
                    suppliers = suppliers.OrderByDescending(s => s.SupplierName);
                    break;
                case "Telephone/fax/email":
                    suppliers = suppliers.OrderBy(s => s.Telephonefaxemail);
                    break;
                case "ZIP Code":
                    suppliers = suppliers.OrderBy(s => s.ZIPCode);
                    break;
                default:  // ID ascending 
                    suppliers = suppliers.OrderBy(s => s.SupplierID);
                    break;
            }

            int pageSize = 100;
            int pageNumber = (page ?? 1);
            return View(suppliers.ToPagedList(pageNumber, pageSize));
            
        }

        public ActionResult Select(int? id, int cr, int screen)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ssupplier ssupplier = db.Suppliers.Find(id);
            if (ssupplier == null)
            {
                return HttpNotFound();
            }
            CR cR = db.CRs.Find(cr);
            cR.Supplier = ssupplier.SupplierID;
            cR.Suppliername = ssupplier.SupplierName;
            db.SaveChanges();
            if (screen == 1)
            { return RedirectToAction("Create", "CRs", new { id = cr }); }
            else { return RedirectToAction("Edit", "CRs", new { id = cr }); }
        }
        // GET: Ssuppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ssupplier ssupplier = db.Suppliers.Find(id);
            if (ssupplier == null)
            {
                return HttpNotFound();
            }
            return View(ssupplier);
        }

        // GET: Ssuppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ssuppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierID,SupplierName,Street,City,State,Country,ZIPCode,Affiliatestore,SupplierRate,Class,Franchise,Telephonefaxemail,ContactName,Status,Type,Rating,LastWAdate")] Ssupplier ssupplier)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(ssupplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ssupplier);
        }

        // GET: Ssuppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ssupplier ssupplier = db.Suppliers.Find(id);
            if (ssupplier == null)
            {
                return HttpNotFound();
            }
            return View(ssupplier);
        }

        // POST: Ssuppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierID,SupplierName,Street,City,State,Country,ZIPCode,Affiliatestore,SupplierRate,Class,Franchise,Telephonefaxemail,ContactName,Status,Type,Rating,LastWAdate")] Ssupplier ssupplier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ssupplier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ssupplier);
        }

        // GET: Ssuppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ssupplier ssupplier = db.Suppliers.Find(id);
            if (ssupplier == null)
            {
                return HttpNotFound();
            }
            return View(ssupplier);
        }

        // POST: Ssuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ssupplier ssupplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(ssupplier);
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
