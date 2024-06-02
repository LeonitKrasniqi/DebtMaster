using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class UpdateUserDto
    {
        [Required]
        public string Name { get; set; }
    }
}
