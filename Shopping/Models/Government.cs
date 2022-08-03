using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Government
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }= DateTime.Now;
        public bool isactive { get; set; }
        public virtual List<City> cities { get; set; }
       
        public virtual List<Order> Orders { get; set; }

    }
}
