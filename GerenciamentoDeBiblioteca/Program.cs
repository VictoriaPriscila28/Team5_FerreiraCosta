using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GerenciamentoDeBiblioteca.Infra.Ioc;

namespace GerenciamentoDeBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adicionar serviços ao contêiner.
            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configurar o pipeline de solicitação HTTP.
            Configure(app);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            
            services.AddInfrastructure(configuration); // Certifique-se que este método de extensão está definido no seu projeto.

            // Adicionar Swagger/OpenAPI
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciamentoDeBiblioteca v1"));
            }

            

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:4200"));
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("index", "Fallback"); // Certifique-se que esse controller existe no seu projeto.
            });
        }
    }
}
