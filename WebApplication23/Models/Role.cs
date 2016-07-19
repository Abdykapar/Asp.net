using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication23.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}