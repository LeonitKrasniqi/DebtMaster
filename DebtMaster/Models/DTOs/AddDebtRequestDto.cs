using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class AddDebtRequestDto
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Guid UserId {  get; set;  }
    }
}
