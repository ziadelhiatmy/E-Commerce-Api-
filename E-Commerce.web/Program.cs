
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Presistence;
using Presistence.Data;
using System.Reflection;
using System.Threading.Tasks;

namespace E_Commerce.web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region Add Service to the container
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection"));
            
            });
            builder.Services.AddScoped<IDataSeeding,DataSeeding>();
            builder.Services.AddAutoMapper(cfg=> { }, typeof(ServiceLayer.AssemblyReference).Assembly);
            #endregion

            var app = builder.Build();
            var Scope = app.Services.CreateScope();
            var ObjectDataSeeding = Scope.ServiceProvider.GetRequiredService<IDataSeeding>();
           await ObjectDataSeeding.DataSeedAsync();
             
            #region Configration the Http request

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion
             
            app.Run(); 
        }
    }
}
