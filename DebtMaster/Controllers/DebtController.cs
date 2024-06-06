using AutoMapper;
using DebtMaster.Data;
using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;
using DebtMaster.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetDebtsByUserId(Guid userId)
        {
            try
            {
                var debts = await debtRepository.GetDebtsByUserIdAsync(userId);
                var debtDtos = mapper.Map<List<UserDebtDto>>(debts);
                return Ok(debtDtos);
            }
            catch (KeyNotFoundException)
            {
               return NotFound();
            }
        }

        [HttpGet("{UserId}")]
        [Authorize(Roles = "Admin, User")]
        public async Task<ActionResult<UserDebtAmountDto>> GetTotalDebt(Guid UserId)
        {
            try
            {
                var result = await debtRepository.GetTotalAmountByUserIdAsync(UserId);
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

    }
}
