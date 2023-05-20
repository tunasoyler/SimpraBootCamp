using Microsoft.EntityFrameworkCore;
using SimpraHW1.Core.Entities;
using SimpraHW1.Core.UnitOfWork;
using SimpraHW1.Data.Context;
using SimpraHW1.Data.Services;
using SimpraHW1.Data.UnitOfWork;
using SimpraHW1.Services.Services;

namespace SimpraHW1.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddDbContext<StaffDb>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IStaffService, StaffService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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