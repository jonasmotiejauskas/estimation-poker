﻿namespace EstimationPoker.ApiService.Models.Dto
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmatin { get; set; }
    }
}
