using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication23.Models
{
    public class Homeland
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int user_id { get; set; }

        public virtual User Users { get; set; }
        public virtual ICollection<Information> Informations { get; set; }
    }
}