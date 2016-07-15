using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication23.Models
{
    public class Information
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int homeland_id { get; set; }

        public virtual Homeland Homelands { get; set; }
    }
}