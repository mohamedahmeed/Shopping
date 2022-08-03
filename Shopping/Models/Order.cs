
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping.Services.Enums;

namespace Shopping.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int ProductWeight { get; set; }
        public string clientName { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int clientID { get; set; }
        public string clientphone1 { get; set; }
        public string clientphone2 { get; set; }
        public string Email { get; set; }
       // public string Government { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
      
       
        public string ShippingType { get; set; }
        public string paymentType { get; set; }
        [ForeignKey("user")]
        public string UserId { get; set; }

        public virtual AppUser user { get; set; }

        [ForeignKey("Government")]
        public Guid GovernmentId { get; set; }
        public states States { get; set; }
        public int price { get; set; }


        public virtual Government Government { get; set; }






    }
}
