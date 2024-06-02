using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DebtMaster.Models.Domain
{
    public class Debt
    {
        [Key]
        public Guid DebtId { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount {  get; set; }

        public Guid UserId {  get; set; }
        [JsonIgnore]
        public User User { get; set; }


    }
}
