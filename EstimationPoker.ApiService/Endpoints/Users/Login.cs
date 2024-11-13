using EstimationPoker.ApiService.Models.Dto;
using EstimationPoker.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstimationPoker.ApiService.Endpoints.Users
{
    public class Login : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/api/authentication/login", async ([FromHeader(Name = "email")] string email, [FromHeader(Name = "password")] string password,
                IAuthenticationService authenticationService,
                IJwtService jwtService) =>
            {
                var user = await authenticationService.LoginAsync(email, password);
                if (user == null)
                {
                    return Results.Unauthorized();
                }

                var token = jwtService.GenerateToken(user.Email, user.Id, user.Role);
                return Results.Ok(new { Token = token });
            });
        }
    }
}
