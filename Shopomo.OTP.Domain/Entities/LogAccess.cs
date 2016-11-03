using System;

namespace Shopomo.OTP.Domain.Entities
{
    public class LogAccess : EntityBase
    {
        public int LogAccessId { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public Boolean Fail { get; set; }
    }
}
