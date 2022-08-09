using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int ProductWeight { get; set; }
        public int Amount { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }


    }
}
