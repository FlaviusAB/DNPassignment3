using System;
using System.Security.Claims;
using LoginExample.Authentication;
using LoginExample.Data;
using LoginExample.Data.HttpServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LoginExample {
public class Startup {
    public Startup(IConfiguration configuration) {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services) {
        services.AddRazorPages();
        services.AddServerSideBlazor();

        services.AddHttpClient<IUsersHttpService, UserHttpService>(client =>
            client.BaseAddress = new Uri("https://localhost:5001/"));
        services.AddHttpClient<IAdultsHttpServices, AdultsHttpServices>(client =>
            client.BaseAddress = new Uri("https://localhost:5001/"));
        
        
        services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

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
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        } else {
            app.UseExceptionHandler("/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints => {
            endpoints.MapBlazorHub();
            endpoints.MapFallbackToPage("/_Host");
        });
    }
}
}