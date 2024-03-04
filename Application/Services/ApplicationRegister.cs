using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public static  class ApplicationRegister
    {
        public static void AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IContact, BLContact>();
        }
    }
}
