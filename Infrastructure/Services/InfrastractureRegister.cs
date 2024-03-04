using Infrastructure.Context;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Infrastructure.Services
{
    public static class InfrastractureRegister
    {
        public static void AddInfrastractureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ContractSystemContext>(options =>
            options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnections")));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
