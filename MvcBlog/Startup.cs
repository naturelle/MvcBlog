
using React.AspNet;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.V8;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MvcCategories
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //React için
            //services.AddReact();

            //// Make sure a JS engine is registered, or you will get an error!
            //services.AddJsEngineSwitcher(options => options.DefaultEngineName = V8JsEngine.EngineName)
            //  .AddV8();

            services.AddControllersWithViews();

            services.AddSession();

            //bu metot sayesind proje seviyesinde authorization 
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();

            //Lognin deðilse her yerde logine yönlendiriyo
            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                }
              );
        }  

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

         //   Initialise ReactJS.NET.Must be before static files.
          //app.UseReact(config =>
          //    {
          //        config
          //        .AddScript("~/js/remarkable.min.js")
          //        .AddScript("~/js/tutorial.jsx");


          //        // If you want to use server-side rendering of React components,
          //        // add all the necessary JavaScript files here. This includes
          //        // your components as well as all of their dependencies.
          //        // See http://reactjs.net/ for more information. Example:
          //        //config
          //        // config.AddScript("C:/Users/Ebru/source/repos/MvcBlog/MvcBlog/wwwroot/js/tutorial.jsx");
          //        //  .AddScript("~/js/Second.jsx");

          //        // If you use an external build too (for example, Babel, Webpack,
          //        // Browserify or Gulp), you can improve performance by disabling
          //        // ReactJS.NET's version of Babel and loading the pre-transpiled
          //        // scripts. Example:
          //        //config
          //        //  .SetLoadBabel(false)
          //        //  .AddScriptWithoutTransform("~/js/bundle.server.js");
          //    });

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1","?code={0}");
            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
