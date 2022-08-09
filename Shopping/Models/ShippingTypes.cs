using System;

namespace Shopping.Models
{
    public class ShippingTypes
    {
        public Guid Id { get; set; }
        public string ShippingType { get; set; }
        public int price { get; set; }
        public virtual Order Order { get; set; }


    }
}
