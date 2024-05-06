using DebtMaster.Data;
using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;
using DebtMaster.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtController : ControllerBase
    {
        private readonly IDebtRepository debtRepository;
        private readonly DebtDbContext dbContext;

        public DebtController(IDebtRepository debtRepository, DebtDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.debtRepository = debtRepository;

        }

        [HttpPost]
        public async Task<IActionResult> CreateDebt([FromBody] AddDebtRequestDto debtDto)
        {
            try
            {
                Debt debt = new Debt
                {
                    DebtorName = debtDto.DebtorName,
                    Description = debtDto.Description,
                    DateTime = debtDto.DateTime,
                    Amount = debtDto.Amount
                };

                Debt createdDebt = await debtRepository.CreateAsync(debt);
                return Ok(createdDebt);
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create debt: " + ex.Message);
            
            }
  }

    }
}
