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
    public class DebtController : ControllerBase
    {
        private readonly IDebtRepository debtRepository;
        private readonly DebtDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public DebtController(IDebtRepository debtRepository, DebtDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.debtRepository = debtRepository;
            this.mapper = mapper;

        }

     
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

    }
}
