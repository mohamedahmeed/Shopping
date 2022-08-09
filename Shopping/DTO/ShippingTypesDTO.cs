using Shopping.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class ShippingTypesDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string ShippingType { get; set; }
        [Required]
        [Range(minimum:1,maximum:5000)]
        public int price { get; set; }
        public virtual Order Order { get; set; }
    }
}
