using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DebtMaster.Models.Domain
{
    public class User
    {
        [Key]
        public Guid UserID { get; set; }

        public string Name { get;set; }


        [JsonIgnore]
        public ICollection<Debt> Debts{ get; set; }

    }
}
