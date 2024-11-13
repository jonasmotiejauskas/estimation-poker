using EstimationPoker.ApiService.Models.Dto;
using EstimationPoker.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstimationPoker.ApiService.Endpoints.Users
{
    public class Registration : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/api/authentication/register", async (
                [FromBody] CreateUserDto userDto,
                IAuthenticationService authenticationService,
                IUserValidator userValidator,
                IUserService userService) =>
            {
                var validationResult = userValidator.ValidateCreateUserDto(userDto);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(string.Join("\r\n", validationResult.Errors));
                }

                if (await userService.GetUserAsync(userDto.Email) != null)
                {
                    return Results.BadRequest($"{userDto.Email} already exists");
                }

                await authenticationService.RegisterAsync(userDto);
                return Results.Ok();
            });
        }
    }
}
