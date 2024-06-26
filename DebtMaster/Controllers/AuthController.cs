﻿using DebtMaster.Models.DTOs;
using DebtMaster.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DebtMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenrepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {

            this.userManager = userManager;
            this.tokenrepository = tokenRepository;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegsiterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                Email = registerRequestDto.Email,
                UserName = registerRequestDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                //Add roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registred!");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Register([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPassword)
                {
                    //Get role for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        //create Token using method created at class TokenRepo
                        var jwtToken = tokenrepository.CreateJwtToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken
                        };
                        return Ok(response);
                    }
                }
            }

            return BadRequest();
        }
    }
}