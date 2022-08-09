using System;

namespace Shopping.Models
{
    public class ShippingPrice
    {
        public Guid Id { get; set; }

        public int FromWeight { get; set; }
        public int ToWeight { get; set; }
        public int Price { get; set; }
        public int extraPrice { get; set; }

        //public virtual Order Order { get; set; }

    }
}
