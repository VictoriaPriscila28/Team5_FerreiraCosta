using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Repositorios;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using GerenciamentoDeBiblioteca_core.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<SistemaGerenciamentoDBContext>(

                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                
                );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ILivroRepositorio, LivroRepositorio>();
            builder.Services.AddScoped<IEmprestimoRepositorio, IEmprestimoRepositorio>(); // Adiciona o repositório de empréstimo
            builder.Services.AddScoped<IServicoEmprestimo, IServicoEmprestimo>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
