using AutoMapper;
using DebtMaster.Models.Domain;
using DebtMaster.Models.DTOs;
using DebtMaster.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebtMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            this.mapper= mapper;
            this.userRepository= userRepository;    
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userEntity = mapper.Map<User>(dto);

                var newUser = await userRepository.CreateAsync(userEntity);
                var userDto = mapper.Map<User>(newUser);

                return CreatedAtAction(nameof(GetUserById), new { id = userDto.UserID }, userDto);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Cannot create a user! ");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                var userDto = mapper.Map<UserDto>(user);
                return Ok(userDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the user.");
            }
        }


    }
}
