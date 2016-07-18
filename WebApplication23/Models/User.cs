using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication23.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [Display(Name="Password")]
        public string Parola { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        
        public virtual ICollection<Homeland> Homelands { get; set; }
    }
}