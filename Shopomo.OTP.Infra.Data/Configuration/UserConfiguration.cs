using Shopomo.OTP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(k => k.UserId);

            Property(p => p.Name)
                .HasMaxLength(300);

            Property(p => p.Email)
                .HasMaxLength(300);
        }
    }
}
