using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class Powers
    {
        [Key]
        public Guid powerId { get; set; }
        public string pageName { get; set; }
        public bool canAdd { get; set; }
        public bool canDelete { get; set; }
        public bool canUpdate { get; set; }
        public bool canSee { get; set; }
        [ForeignKey("user")]
        public string webSiteUserID { get; set; }
        public  virtual AppUser user { get; set; }

    }
}
