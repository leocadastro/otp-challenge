using Shopomo.OTP.Domain.Entities;
using Shopomo.OTP.Infra.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Context
{
    public class ShopomoContext : DbContext
    {
        public ShopomoContext()
            : base("ShopomoConnection")
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public DbSet<User> User { get; set; }
        public DbSet<LogAccess> LogAccess { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new LogAccessConfiguration());
        }

        public override int SaveChanges()
        {
            UpdateDate();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            UpdateDate();

            return await base.SaveChangesAsync();
        }

        private void UpdateDate()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    entry.Property("ModifiedDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedDate").IsModified = false;
                    entry.Property("ModifiedDate").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
