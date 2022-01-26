namespace Nsk.OnlineStore.Web.Site.Migrations
{
    using Nsk.OnlineStore.Web.Site.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    internal sealed class Configuration : DbMigrationsConfiguration<Nsk.OnlineStore.Web.Site.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Nsk.OnlineStore.Web.Site.Models.ApplicationDbContext context)
        {
        //  This method will be called after migrating to the latest version.
        //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
        //  to avoid creating duplicate seed data. E.g.
        //
        //    context.People.AddOrUpdate(
        //      p => p.FullName,
        //      new Person { FullName = "Andrew Peters" },
        //      new Person { FullName = "Brice Lambson" },
        //      new Person { FullName = "Rowan Miller" }
        //    );
        //
        //var user = new ApplicationUser { UserName = "alfred@alki.com", Email = "alfred@alki.com", CustomerId = "ALFKI" };
        //var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //var result = userManager.CreateAsync(user, "F@k3p@ssw0rd");
        }
    }
}