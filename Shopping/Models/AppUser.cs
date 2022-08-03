using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class AppUser:IdentityUser
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)][Key]
        //public  Guid id { get; set; }
        public string City { get; set; }
        public string Government { get; set; }
        public string Adress { get; set; }
        public int Age { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual ICollection<Powers> Powers { get; set; }
        

    }
}
