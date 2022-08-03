using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class City
    {
        public Guid Id { get; set; }
        public string cityName { get; set; }
        public string governmentName { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

        public int price { get; set; }

        public bool isactive { get; set; }
        [ForeignKey("government")]
        public Guid governmentId { get; set; }
        public Government government { get; set; }

    }
}
