using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtMaster.Models.Domain
{
    public class Debt
    {
        [Key]
        public Guid DebtId { get; set; }
        public string DebtorName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount {  get; set; }

        [ForeignKey("User")]
        public Guid UserId {  get; set; }
        public User User { get; set; }


    }
}
