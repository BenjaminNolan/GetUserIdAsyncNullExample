using GetUserIdAsyncNullExample.Data;
using GetUserIdAsyncNullExample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GetUserIdAsyncNullExample
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
            services.AddMvc();

            services.AddDbContext<ExampleContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<User, Role>(c => {
                c.Lockout.MaxFailedAccessAttempts = 5;

                c.Password.RequireDigit = false;
                c.Password.RequiredLength = 7;
                c.Password.RequiredUniqueChars = 4;
                c.Password.RequireLowercase = false;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;

                c.SignIn.RequireConfirmedEmail = true;
                c.SignIn.RequireConfirmedPhoneNumber = false;

                c.User.RequireUniqueEmail = true;
            })
                .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ExampleContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Example}/{action=Index}/{id?}");
            });

            app.UseAuthentication();
        }
    }
}
