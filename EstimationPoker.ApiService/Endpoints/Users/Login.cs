using EstimationPoker.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstimationPoker.ApiService.Endpoints.Users
{
    /*public class Login : IEndpoint
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtService _jwtService;

        public Login(
            IAuthenticationService authenticationService,
            IJwtService jwtService)
        {
            _authenticationService = authenticationService;
            _jwtService = jwtService;
        }

        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/authentication/login", async (UserDto userDto) =>
            {
                var user = await _authenticationService.AuthenticateAsync(loginDto);
                if (user == null)
                {
                    return Results.Unauthorized();
                }

                var token = _jwtService.GenerateToken(user.Email, user.UserId, user.Role);
                return Results.Ok(new { Token = token });
            });
        }

        public async Task<ActionResult> Login([FromHeader(Name = "username")] string username, [FromHeader(Name = "password")] string password)
        {
            var user = await _authenticationService.LoginAsync(username, password);
            if (user == null)
            {
                return BadRequest("Incorrect username or password");
            }

            var token = _jwtService.GenerateToken(username, user.UserId, user.Role);
            return Ok(token);
        }
    }*/
}
