using System;

namespace Shopomo.OTP.Domain.Entities
{
    public class EntityBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
