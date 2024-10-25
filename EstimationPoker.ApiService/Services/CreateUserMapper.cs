using EstimationPoker.ApiService.Models.Dto;
using EstimationPoker.ApiService.Models;
using System.Net;

namespace EstimationPoker.ApiService.Services
{
    public interface ICreateUserMapper
    {
        public User Bind(CreateUserDto user);
    }
    public class CreateUserMapper : ICreateUserMapper
    {
        private readonly IUserCredentialService _userCredentialService;

        public CreateUserMapper(IUserCredentialService userCredentialService)
        {
            _userCredentialService = userCredentialService;
        }

        public User Bind(CreateUserDto dto)
        {
            var hashedCredentials = _userCredentialService.GetHashedCredentials(dto.Password);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hashedCredentials.Password,
                Salt = hashedCredentials.Salt,
                Role = "User",
            };

            return user;
        }
    }
}
