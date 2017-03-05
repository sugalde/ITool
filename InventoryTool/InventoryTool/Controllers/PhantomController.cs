using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryTool.Controllers
{
    public class PhantomController : Controller
    {
        // GET: Phantom
        public ActionResult Index()
        {
            return View();
        }

        // GET: Phantom/Search
        public ActionResult Search()
        {
            return RedirectToAction("Phantom", "Fleets");
        }

        // GET: Phantom/List
        public ActionResult List()
        {
            return RedirectToAction("Index", "CRs");
        }

        // GET: Phantom/General
        public ActionResult General()
        {
            return RedirectToAction("General", "CRs");
        }

        // GET: Phantom/Delete/5
        public ActionResult APlist()
        {
            return RedirectToAction("APlist", "CRs");
        }

        
    }
}
