
using ApiLogin.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLogin
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

            #region [Cors]
            builder.Services.AddCors();
            #endregion

            builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApiLoginDbContext>(options =>
            options.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=daniel;Password=mysecretpassword;"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #region [Cors]
            app.UseCors(c =>
            {
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
                c.AllowAnyHeader();
            });
            #endregion

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            app.UseCors();

        }
    }
}