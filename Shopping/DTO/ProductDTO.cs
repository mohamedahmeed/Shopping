using Shopping.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required][Range(0,5000)]

        public int ProductWeight { get; set; }
        [Required]
        [Range(0, 5000)]

        public int Amount { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
