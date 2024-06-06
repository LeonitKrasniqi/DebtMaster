using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class RegsiterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
