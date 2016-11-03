using Shopomo.OTP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopomo.OTP.Infra.Data.Configuration
{
    public class LogAccessConfiguration : EntityTypeConfiguration<LogAccess>
    {
        public LogAccessConfiguration()
        {
            HasKey(k => k.LogAccessId);

            Property(p => p.Email)
                .HasMaxLength(300);
        }
    }
}
