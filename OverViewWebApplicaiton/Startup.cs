using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OverViewWebApplicaiton.Filters;
using OverViewWebApplicaiton.Options;

namespace OverViewWebApplicaiton
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
            //MVC related services
            services.AddMvc(options=>
            {
            });
            //Authentication services
            services.AddAuthentication("cookie").AddCookie("cookie", options =>
             {
                 options.LoginPath = "/Account/Login";
                 options.LogoutPath = "/Account/Logout";
             });
            services.AddOptions();
            //Configure Logging;
            services.AddLogging(configure =>
            {
                configure.AddConsole();
                configure.AddDebug();
                configure.AddConsole(options =>
                {
                    options.IncludeScopes = false;
                });
            });
            services.Configure<UserProfileOptions>(Configuration.GetSection("UserProfieOption"));
            services.AddSingleton<CustomerFilter>();

            ApplicationPartManager applicationPartManager = services.BuildServiceProvider().GetService<ApplicationPartManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            //StaticeFile middleware
            app.UseStaticFiles();
            //Authentication middleware
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
