namespace Shopomo.OTP.Domain.Entities
{
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
