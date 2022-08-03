using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class RoleDTO
    {
        [Required]
        public string roleName { get; set; }
    }
}
