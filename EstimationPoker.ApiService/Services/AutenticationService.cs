using EstimationPoker.ApiService.Models;
using EstimationPoker.ApiService.Models.Dto;
using EstimationPoker.ApiService.Repositories;
using EstimationPoker.ApiService.Services;

namespace EstimationPoker.ApiService
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(CreateUserDto userDto);
        Task<User?> LoginAsync(string email, string password);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICreateUserMapper _createUserMapper;
        private readonly IUserCredentialService _userCredentialService;

        public AuthenticationService(IUserRepository userRepository, ICreateUserMapper createUserMapper, IUserCredentialService userCredentialService)
        {
            _userRepository = userRepository;
            _createUserMapper = createUserMapper;
            _userCredentialService = userCredentialService;
        }

        public async Task RegisterAsync(CreateUserDto userDto)
        {
            var user = _createUserMapper.Bind(userDto);

            await _userRepository.AddUserAsync(user);
        }


        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserAsync(email);

            if (user == null)
            {
                return null;
            }

            if (_userCredentialService.VerifyPasswordHash(password, user.Password, user.Salt))
            {
                return user;
            }

            return null;
        }
    }
}