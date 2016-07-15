using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication23.Models
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public string Parola { get; set; }
        public string email { get; set; }
        
        public virtual ICollection<Homeland> Homelands { get; set; }
    }
}