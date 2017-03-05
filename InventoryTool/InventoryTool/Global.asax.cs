using InventoryTool.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace InventoryTool
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                    Models.InventoryToolContext,
                    Migrations.Configuration>()); // Para que siempre busque la ultima version
            ApplicationDbContext db = new ApplicationDbContext(); // para conectar a la base de datos del membership
            CreateRoles(db);  // Creamos el metodo de Creacion de Roles
            CreateAdmin(db);  // Creamos el metodo de Creacion del Admnistrador
            AddPermissionsToAdmin(db); // Creamos el metodo de Permisos del Admnistrador
            db.Dispose();     // Liberamos el objeto y cerramos la base de datos
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void AddPermissionsToAdmin(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var user = userManager.FindByName("hsagaon@elementcorp.com");
            var user2 = userManager.FindByName("sugalde@elementcorp.com");

            if (!userManager.IsInRole(user.Id, "InventoryView")) // Agregar Permisos
                userManager.AddToRole(user.Id, "InventoryView");

            if (!userManager.IsInRole(user.Id, "InventoryEdit")) 
                userManager.AddToRole(user.Id, "InventoryEdit");

            if (!userManager.IsInRole(user.Id, "InventoryCreate")) 
                userManager.AddToRole(user.Id, "InventoryCreate");

            if (!userManager.IsInRole(user.Id, "InventoryDelete")) 
                userManager.AddToRole(user.Id, "InventoryDelete");

            if (!userManager.IsInRole(user.Id, "APhantomView")) // Agregar Permisos
                userManager.AddToRole(user.Id, "APhantomView");

            if (!userManager.IsInRole(user.Id, "APhantomEdit"))
                userManager.AddToRole(user.Id, "APhantomEdit");

            if (!userManager.IsInRole(user.Id, "APhantomCreate"))
                userManager.AddToRole(user.Id, "APhantomCreate");

            if (!userManager.IsInRole(user.Id, "APhantomDelete"))
                userManager.AddToRole(user.Id, "APhantomDelete");

            if (!userManager.IsInRole(user.Id, "Administrator"))
                userManager.AddToRole(user.Id, "Administrator");

            if (!userManager.IsInRole(user2.Id, "PhantomView")) // Agregar Permisos
                userManager.AddToRole(user2.Id, "PhantomView");

            if (!userManager.IsInRole(user2.Id, "PhantomEdit"))
                userManager.AddToRole(user2.Id, "PhantomEdit");

            if (!userManager.IsInRole(user2.Id, "PhantomCreate"))
                userManager.AddToRole(user2.Id, "PhantomCreate");

            if (!userManager.IsInRole(user2.Id, "PhantomDelete"))
                userManager.AddToRole(user2.Id, "PhantomDelete");

            if (!userManager.IsInRole(user2.Id, "Administrator"))
                userManager.AddToRole(user2.Id, "Administrator");
        }

        private void CreateAdmin(ApplicationDbContext db)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var user = userManager.FindByName("hsagaon@elementcorp.com");
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "hsagaon@elementcorp.com",
                    Email= "hsagaon@elementcorp.com"
                };
                userManager.Create(user, "Happy123$");
            }

        }

        private void CreateRoles(ApplicationDbContext db)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            // Administrator
            if (!roleManager.RoleExists("Administrator"))
            {
                roleManager.Create(new IdentityRole("Administrator"));
            }
            // Se crean los roles
            if (!roleManager.RoleExists("InventoryView"))
            {
                roleManager.Create(new IdentityRole("InventoryView"));
            }
            if (!roleManager.RoleExists("InventoryEdit"))
            {
                roleManager.Create(new IdentityRole("InventoryEdit"));
            }
            if (!roleManager.RoleExists("InventoryCreate"))
            {
                roleManager.Create(new IdentityRole("InventoryCreate"));
            }
            if (!roleManager.RoleExists("InventoryDelete"))
            {
                roleManager.Create(new IdentityRole("InventoryDelete"));
            }
            // PhantomRoles
            if (!roleManager.RoleExists("PhantomView"))
            {
                roleManager.Create(new IdentityRole("PhantomView"));
            }
            if (!roleManager.RoleExists("PhantomEdit"))
            {
                roleManager.Create(new IdentityRole("PhantomEdit"));
            }
            if (!roleManager.RoleExists("PhantomCreate"))
            {
                roleManager.Create(new IdentityRole("PhantomCreate"));
            }
            if (!roleManager.RoleExists("PhantomDelete"))
            {
                roleManager.Create(new IdentityRole("PhantomDelete"));
            }
            //AP- PhantomRoles
            if (!roleManager.RoleExists("APhantomView"))
            {
                roleManager.Create(new IdentityRole("APhantomView"));
            }
            if (!roleManager.RoleExists("APhantomEdit"))
            {
                roleManager.Create(new IdentityRole("APhantomEdit"));
            }
            if (!roleManager.RoleExists("APhantomCreate"))
            {
                roleManager.Create(new IdentityRole("APhantomCreate"));
            }
            if (!roleManager.RoleExists("APhantomDelete"))
            {
                roleManager.Create(new IdentityRole("APhantomDelete"));
            }
        }
    }
}
