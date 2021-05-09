using BlazorAssignmentWebApplication.Data.Persistence;
using BlazorAssignmentWebApplication.repository;
using BlazorAssignmentWebApplication.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BlazorAssignmentWebApplication
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IAdultRepo, AdultRepo>();
            services.AddScoped<IAdultService, AdultService>();
            
            services.AddDbContextFactory<DatabaseContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("Default"));
            });

            services.AddScoped<DatabaseContext>(p => 
                p.GetRequiredService<IDbContextFactory<DatabaseContext>>()
                    .CreateDbContext());
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "BlazorAssignmentWebApplication", Version = "v1"});
            });
            
            services.AddAuthorization(options => {
            
                options.AddPolicy("MustBeTeacherHigher4", policy =>
                    policy.RequireAuthenticatedUser()
                        .RequireClaim("Role", "Teacher")
                        .RequireClaim("Level", "4","5"));
                options.AddPolicy("MustBeTeacher", policy =>
                    policy.RequireAuthenticatedUser()
                        .RequireClaim("Role", "Teacher"));

                options.AddPolicy("Student", policy =>
                    policy.RequireAuthenticatedUser()
                        .RequireClaim("Role", "Student"));
            
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorAssignmentWebApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}                                                                               