namespace DebtMaster.Models.DTOs
{
    public class DebtDto
    {
        public Guid DebtId { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
    }
}
