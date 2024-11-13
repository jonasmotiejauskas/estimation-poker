using EstimationPoker.ApiService.Models.Dto;
using EstimationPoker.ApiService.Models;

namespace EstimationPoker.ApiService.Services
{
    public interface IUserDtoMapper
    {
        public UserDto Bind(User user);
    }
    public class UserDtoMapper : IUserDtoMapper
    {
        public UserDto Bind(User user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
