﻿using System.ComponentModel.DataAnnotations;

namespace DebtMaster.Models.DTOs
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
