using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class CreateUserDto
    {
        [Required]
        public string Name {  get; set; }
    }
}
