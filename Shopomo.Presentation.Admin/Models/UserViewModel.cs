using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopomo.Presentation.Admin.Models
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(400)]
        public string Name { get; set; }
        [StringLength(400)]
        public string Email { get; set; }
    }
}