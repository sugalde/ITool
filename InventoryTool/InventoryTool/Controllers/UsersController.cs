using InventoryTool.Models;
using InventoryTool.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace InventoryTool.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Users
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var usersView = new List<UserView>();

            foreach(var user in users)
            {
                var userView = new UserView
                {
                    Email = user.Email,
                    Name = user.UserName,
                    UserID = user.Id
                };

                usersView.Add(userView);
            }

            return View(usersView);
        }

        public ActionResult Roles(string userID)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var roles = roleManager.Roles.ToList();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            var rolesView = new List<RoleView>();

            foreach (var item in user.Roles)
            {
                var role = roles.Find(r => r.Id == item.RoleId);

                var roleView = new RoleView
                {
                    RoleID = role.Id,
                    Name = role.Name
                };

                rolesView.Add(roleView);
            }

            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
                Roles = rolesView
            };

            return View(userView);
        }

        public ActionResult AddRole(string userID)
        {
            if(string.IsNullOrEmpty(userID))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var users = userManager.Users.ToList();
            var user = users.Find(u => u.Id == userID);

            if(user == null)
            {
                return HttpNotFound();
            }
            var userView = new UserView
            {
                Email = user.Email,
                Name = user.UserName,
                UserID = user.Id,
            };

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var list = roleManager.Roles.ToList();
            list.Add(new IdentityRole { Id = "", Name = "Seleccione un rol... " });
            list = list.OrderBy(r => r.Name).ToList();
            ViewBag.RoleID = new SelectList(list, "Id", "Name"); 

            return View(userView);
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