using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure.Services
{
    public static class InfrastractureRegister
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
