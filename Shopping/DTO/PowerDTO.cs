using Shopping.Models;
using System;

namespace Shopping.DTO
{
    public class PowerDTO
    {
        public Guid powerId { get; set; }
        public string pageName { get; set; }
        public bool canAdd { get; set; }
        public bool canDelete { get; set; }
        public bool canUpdate { get; set; }
        public bool canSee { get; set; }
        public string webSiteUserID { get; set; }
        public AppUser user { get; set; }
    }
}
