using AutoMapper;
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
    public class DebtController(IDebtRepository debtRepository, IMapper mapper) : ControllerBase
    {
        private readonly IDebtRepository debtRepository = debtRepository;
        private readonly IMapper mapper = mapper;

        [HttpPost]
        public async Task<IActionResult> AddDebt([FromBody] AddDebtRequestDto addDebtRequestDto)
        {
            try
            {

                var debt = mapper.Map<Debt>(addDebtRequestDto);


                var createdDebt = await debtRepository.CreateAsync(debt);


                return Ok(createdDebt);
            }
            catch (ArgumentException ex)
            {

                return BadRequest(ex.Message);
            }
          
        }

        [HttpGet]
        public async Task<IActionResult> GetDebts()
        {
            try
            {
                var debts = await debtRepository.GetAllAsync();
                var debtDtos = mapper.Map<List<DebtDto>>(debts);

                return Ok(debtDtos);

            }
            catch(ArgumentException ex)
            {
                return BadRequest($"Could not find {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetDebtsByUserId(Guid userId)
        {
            try
            {
                var debts = await debtRepository.GetDebtsByUserIdAsync(userId);
                var debtDtos = mapper.Map<List<UserDebtDto>>(debts);
                return Ok(debtDtos);
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Could not find debts for user {userId}: {ex.Message}");
            }
        }

    }
}
