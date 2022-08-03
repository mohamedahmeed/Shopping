using System.ComponentModel.DataAnnotations;

namespace Shopping.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required][DataType(DataType.Password)]
        public string Password { get; set; }
        public bool ispresist { get; set; }
    }
}
