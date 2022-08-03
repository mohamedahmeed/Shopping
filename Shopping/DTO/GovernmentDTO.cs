using Shopping.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class GovernmentDTO
    {
        public Guid Id { get; set; }
        [Required]
        [UniqueGovernmentAttripute]
        public string Name { get; set; }
        [Required]

        public DateTime date { get; set; } = DateTime.Now;
        public bool isactive { get; set; }
    }
}
