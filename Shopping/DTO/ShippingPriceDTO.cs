using Shopping.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class ShippingPriceDTO
    {
        public Guid Id { get; set; }
        [Range(minimum: 1, maximum: 5000)]
        [Required]
        public int FromWeight { get; set; }
        [Range(minimum: 1, maximum: 5000)]
        [Required]
        public int ToWeight { get; set; }
        [Range(minimum: 1, maximum: 5000)]
        [Required]
        public int Price { get; set; }
        [Required]
        [Range(minimum:1,maximum:5000)]
        public int extraPrice { get; set; }

        public virtual Order Order { get; set; }
    }
}
