using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Application.Mappings;
using GerenciamentoDeBiblioteca.Application.Services;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
using GerenciamentoDeBiblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

            });
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();

            //Services
            services.AddScoped<IClienteService, ClienteService>();


            return services;
        }
    }
}
