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

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [Required]
        [StringLength(400)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}