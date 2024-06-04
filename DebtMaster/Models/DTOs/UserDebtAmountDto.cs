namespace DebtMaster.Models.DTOs
{
    public class UserDebtAmountDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public decimal TotalAmount {  get; set; }
    }
}
