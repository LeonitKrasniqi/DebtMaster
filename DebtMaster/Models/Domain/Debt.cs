using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.Domain
{
    public class Debt
    {
        [Key]
        public Guid DebtorId { get; set; }
        public string DebtorName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount {  get; set; }


    }
}
