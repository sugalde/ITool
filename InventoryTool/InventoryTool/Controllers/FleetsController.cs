using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using InventoryTool.Models;
using PagedList;

namespace InventoryTool.Controllers
{
    public class FleetsController : Controller
    {
        private InventoryToolContext db = new InventoryToolContext();

        // GET: Fleets
        [Authorize(Roles = "View")]
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "LogNumber" : "";
            ViewBag.DateSortParm = sortOrder == "UnitNumber" ? "date_desc" : "Date";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var fleets = from s in db.Fleets
                         select s; 

            if (!String.IsNullOrEmpty(searchString))
                fleets = fleets.Where(s => s.LogNumber.ToString().Contains(searchString) || s.FleetNumber.ToString().Contains(searchString));
            else
                fleets = fleets.Take(200);

            switch (sortOrder)
            {
                case "LogNumber":
                    fleets = fleets.OrderByDescending(s => s.LogNumber);
                    break;
                case "UnitNumber":
                    fleets = fleets.OrderBy(s => s.UnitNumber);
                    break;
                case "date_desc":
                    fleets = fleets.OrderByDescending(s => s.Inservice_process);
                    break;
                default:
                    fleets = fleets.OrderBy(s => s.Inservice_date);
                    break;
            }

            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(fleets);//.ToPagedList(pageNumber, pageSize));
        }

        // GET: Fleets/Details/5
        [Authorize(Roles = "View")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // GET: Fleets/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fleets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FleetID,LogNumber,CorpCode,FleetNumber,UnitNumber,VinNumber,ContractType,Make,ModelCar,ModelYear,BookValue,CapCost,Inservice_date,Inservice_process,Original_Inservice,Original_Process,Offroad_date,Offroad_process,Sold_date,Sold_process,Cancel_Unit_ind,Amort_term,Leased_months_billed,Psp_date,Psp_process,End_date,UnitAdd_date,ScontrNumber,Amort,LicenseNumber,State,Roe,DealerName,SignedDate,Delivery_date,Insurance,Secdep,DepartCode,Residual_Amount,Level,LevelName,TTL,OutletCode,OutletName")] Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                db.Fleets.Add(fleet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fleet);
        }

        // GET: Fleets/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FleetID,LogNumber,CorpCode,FleetNumber,UnitNumber,VinNumber,ContractType,Make,ModelCar,ModelYear,BookValue,CapCost,Inservice_date,Inservice_process,Original_Inservice,Original_Process,Offroad_date,Offroad_process,Sold_date,Sold_process,Cancel_Unit_ind,Amort_term,Leased_months_billed,Psp_date,Psp_process,End_date,UnitAdd_date,ScontrNumber,Amort,LicenseNumber,State,Roe,DealerName,SignedDate,Delivery_date,Insurance,Secdep,DepartCode,Residual_Amount,Level,LevelName,TTL,OutletCode,OutletName")] Fleet fleet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fleet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fleet);
        }

        // GET: Fleets/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fleet fleet = db.Fleets.Find(id);
            if (fleet == null)
            {
                return HttpNotFound();
            }
            return View(fleet);
        }

        // POST: Fleets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fleet fleet = db.Fleets.Find(id);
            db.Fleets.Remove(fleet);
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
