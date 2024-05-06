namespace DebtMaster.Models.DTOs
{
    public class AddDebtRequestDto
    {
        public string DebtorName { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
    }
}
