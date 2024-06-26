using Client.Service;
using Client.SQLServer.DAL;

namespace Client.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .Configure<ConnectionStringConfig>(c =>
                {
                    c.Default = builder.Configuration.GetConnectionString("Default");
                })
                .AddDbContext<WebDbContext>();
            builder.Services.AddScoped<ClientService>();
            builder.Services.AddCors(config =>
            {
                config.AddPolicy("Cors",p =>
                {
                    p.AllowAnyHeader().AllowAnyMethod().AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("Cors");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
