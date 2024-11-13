using EstimationPoker.ApiService.Database;
using Microsoft.EntityFrameworkCore;

namespace EstimationPoker.ApiService.Endpoints.Users
{
    public class GetAllUsers : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/users", async (EstimationPokerDbContext dbContext) =>
            {
                var users = await dbContext.Users.ToListAsync();
                return users;
            });
        }
    }
}
