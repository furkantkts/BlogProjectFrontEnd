using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.ApiServices.Concreate;
using FurkanBlogProjectFrontEnd.ApiServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FurkanBlogProjectFrontEnd
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddHttpClient<IBlogApiService,BlogApiManager>();
            services.AddHttpClient<IAuthApiService,AuthApiManager>();
            services.AddHttpClient<ICategoryApiService,CategoryApiManager>();
            services.AddHttpClient<IImageApiService,ImageApiManager>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSession();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"areas",
                    pattern:"[area}/{controller=Home}/{acction=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name:default,
                    pattern:"{controller=Home}/{acction=Index}/{id?}"
                );
            });
        }
    }
}
