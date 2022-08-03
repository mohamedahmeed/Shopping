using Shopping.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class CityDTO
    {
        public Guid Id { get; set; }
        [Required][UniqueCityAttripute]
        public string cityName { get; set; }
        
        public DateTime date { get; set; } = DateTime.Now;
        [Required]
        [Range(minimum:5,maximum:5000)]
        public int price { get; set; }
        public Guid governmentId { get; set; }
        public bool isactive { get; set; }
        public Government government { get; set; }

    }
}
