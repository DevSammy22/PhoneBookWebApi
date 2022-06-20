using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhoneBookCore.Dtos.Mapping;
using PhoneBookCore.Services.Implementations;
using PhoneBookInfrastructure.Context;
using PhoneBookInfrastructure.Repositories.Implementations;
using PhoneBookInfrastructure.Repositories.Interfaces;
using PhoneBookInfrastructure.Seeder;

namespace PhoneBookApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<AppDbContext>
           (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPhoneBookEntry, PhoneBookEntry>();
            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddAutoMapper(typeof(PhoneBookMapping));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBookApi", Version = "v1" });
            });
           
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44312/api/v1/PhoneBookEntry/AddEntry", "https://localhost:44312/api/v1/PhoneBookEntry/GetAllEntries")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBookApi v1"));
            }

            DataSeeder.Seeder(context);
            app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
