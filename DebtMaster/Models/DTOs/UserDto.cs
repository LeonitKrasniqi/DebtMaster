using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class UserDto
    {
        [Required]
        public Guid UserID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
