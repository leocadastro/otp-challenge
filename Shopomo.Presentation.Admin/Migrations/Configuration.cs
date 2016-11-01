namespace Shopomo.Presentation.Admin.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shopomo.Presentation.Admin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Shopomo.Presentation.Admin.Models.ApplicationDbContext";
        }

        protected override void Seed(Shopomo.Presentation.Admin.Models.ApplicationDbContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "admin@admin.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser
                {
                    UserName = "admin@admin.com",
                    PhoneNumber = "0797697898",
                    Email = "admin@admin.com"
                };
                userManager.Create(userToInsert, "qwer1234");
            }
        }
    }
}
