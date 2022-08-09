using Shopping.Models;
using Shopping.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Shopping.Services.Enums;

namespace Shopping.DTO
{
    public class OrderDTO
    {
       // private readonly Shipping dp;
        //public OrderDTO()
        //{

        //}
        //public OrderDTO(Shipping dp)
        //{
        //    this.dp = dp;
        //}
        public Guid Id { get; set; }
        public string clientName { get; set; }
       
        public string clientphone1 { get; set; }
        public string clientphone2 { get; set; }
        public string Email { get; set; }
        
        public string City { get; set; }
        public string Adress { get; set; }
        public bool Tovillage { get; set; }

        public string UserId { get; set; }

        public virtual AppUser user { get; set; }

        public Guid cityId { get; set; }

        public states States { get; set; }

        public virtual City city { get; set; }
        public Guid GovernmentId { get; set; }

        //public virtual Government Government { get; set; }
     
        public Guid ShippingTypesId { get; set; }

        public  ShippingTypes ShippingTypes { get; set; }
        public  decimal price { get; set; }

        //public decimal Price
        //{
        //    get { return Price; }
        //    set
        //    {
        //        var shippingprice=  dp.ShippingTypes.Where(x => x.Id == ShippingTypesId).Select(x => x.price).FirstOrDefault();
        //        var cityPrice=  dp.cities.Where(x => x.Id == cityId).Select(x => x.price).FirstOrDefault();
        //        var Price = (decimal)shippingprice + (decimal)cityPrice;
        //        Price = value;
        //    }
        //}
        public  List<Product> Products { get; set; }
    }
}

