using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.Domain
{
    public class Debt
    {
        [Key]
        public Guid Id { get; set; }
        public string DebtorName { get; set; }

    }
}
