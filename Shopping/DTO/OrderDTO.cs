using Shopping.Models;
using Shopping.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Shopping.Services.Enums;

namespace Shopping.DTO
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]

        public int ProductWeight { get; set; }
        [Required]

        public string clientName { get; set; }
        [Required]

        public string clientphone1 { get; set; }
        

        public string clientphone2 { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public Guid GovernmentId { get; set; }

        [Required]

        public string City { get; set; }
        [Required]

        public string Adress { get; set; }

       
        [Required]

        public string ShippingType { get; set; }
        [Required]

        public string paymentType { get; set; }
        public virtual Government Government { get; set; }
        public int price { get; set; }

        public states States { get; set; }

        
    }
}

