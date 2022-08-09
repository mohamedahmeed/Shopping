
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
      
        public string clientName { get; set; }
       
        public string clientphone1 { get; set; }
        public string clientphone2 { get; set; }
        public string Email { get; set; }
     
      
        public string Adress { get; set; }
      
        [ForeignKey("user")]
        public string UserId { get; set; }
        public bool Tovillage { get; set; }

        public virtual AppUser user { get; set; }

        [ForeignKey("city")]
        public Guid cityId { get; set; }
        public states States { get; set; }
        public virtual City city { get; set; }
        public decimal price { get; set; }

        //[ForeignKey("ShippingPrice")]
        //public Guid  ShipPriceId { get; set; }

        //public virtual ShippingPrice ShippingPrice { get; set; }

        [ForeignKey("ShippingTypes")]
        public Guid ShippingTypesId { get; set; }

        public virtual ShippingTypes ShippingTypes { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
