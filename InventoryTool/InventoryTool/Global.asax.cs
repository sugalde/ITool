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

            if (!userManager.IsInRole(user.Id, "View")) // Agregar Permisos
                userManager.AddToRole(user.Id, "View");

            if (!userManager.IsInRole(user.Id, "Edit")) 
                userManager.AddToRole(user.Id, "Edit");

            if (!userManager.IsInRole(user.Id, "Create")) 
                userManager.AddToRole(user.Id, "Create");

            if (!userManager.IsInRole(user.Id, "Delete")) 
                userManager.AddToRole(user.Id, "Delete");

            if (!userManager.IsInRole(user.Id, "Prueba"))
                userManager.AddToRole(user.Id, "Prueba");
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

            // Se crean los roles
            if (!roleManager.RoleExists("View"))
            {
                roleManager.Create(new IdentityRole("View"));
            }
            if (!roleManager.RoleExists("Edit"))
            {
                roleManager.Create(new IdentityRole("Edit"));
            }
            if (!roleManager.RoleExists("Create"))
            {
                roleManager.Create(new IdentityRole("Create"));
            }
            if (!roleManager.RoleExists("Delete"))
            {
                roleManager.Create(new IdentityRole("Delete"));
            }

        }
    }
}
