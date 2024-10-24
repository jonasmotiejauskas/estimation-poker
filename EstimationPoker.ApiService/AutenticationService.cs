using EstimationPoker.ApiService.Models;

/*namespace EstimationPoker.ApiService
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(CreateUserDto userDto);
        Task<User?> LoginAsync(string username, string password);
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


        public async Task<User?> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserAsync(username);

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
}*/