using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopomo.Presentation.Admin.Models
{
    public class LogAccessViewModel
    {
        [Key]
        public int LogAccessId { get; set; }
        public string Email { get; set; }
        public DateTime Time { get; set; }
        public Boolean Fail { get; set; }
    }
}