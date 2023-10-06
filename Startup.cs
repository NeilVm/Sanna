namespace registrosanna;
using registrosanna.Data;
using Microsoft.EntityFrameworkCore;
using registrosanna.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using registrosanna.Services;
using registrosAuthService = registrosanna.Services.AuthService;



public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddScoped<AuthService>();
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:8100") // Reemplaza con la URL de tu aplicación
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
        });
    }

    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerUI();
            app.UseSwagger();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseSwaggerUI();

        app.UseSwagger();

        app.UseCors("AllowSpecificOrigin");

        app.UseAuthorization();

        IApplicationBuilder applicationBuilder = app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}