namespace Shopomo.OTP.Infra.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Shopomo.OTP.Infra.Data.Context.ShopomoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Shopomo.OTP.Infra.Data.Context.ShopomoContext context)
        {
            if (!(context.User.Any(u => u.Email == "leonardo@gmail.com")))
            {
                var user = new User() { Email = "leonardo@gmail.com", Name = "Leonardo", CreatedDate = DateTime.Now };
                context.User.Add(user);
            }
        }
    }
}
