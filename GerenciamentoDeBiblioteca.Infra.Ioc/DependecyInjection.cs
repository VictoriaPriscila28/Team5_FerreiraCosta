﻿using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Application.Mappings;
using GerenciamentoDeBiblioteca.Application.Services;
using GerenciamentoDeBiblioteca.Domain.Account;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
using GerenciamentoDeBiblioteca.Infra.Data.Identity;
using GerenciamentoDeBiblioteca.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

                //options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                //    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            // Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            services.AddScoped<ISistemaRepository, SistemaRepository>();

            services.AddScoped<IMultaRepository, MultaRepository>();





            // Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();

            services.AddScoped<IMultaRepository, MultaRepository>();

            services.AddScoped<ISistemaService, SistemaService>();




            return services;
        }
    }
}
