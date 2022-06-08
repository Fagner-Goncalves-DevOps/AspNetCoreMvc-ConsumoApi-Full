using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppMvcFull.Extensions;

namespace WebAppMvcFull.Configuration
{
    public static class WebAppConfig
    {
        public static void AddMvcConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(configuration);

        }
                        
        public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env) 
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error/500");
            //    app.UseStatusCodePagesWithRedirects("/Error/{0}");
            //    app.UseHsts();
            //}

            app.UseExceptionHandler("/Error/500");
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            app.UseHsts();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //esse vem da startup
            app.UseIdentityConfiguration();

            app.UseMiddleware<ExceptionMiddleware>(); //todos os request passar por ele, centralizando os erros neles, sem precisar de try catch

            //esse cara sai
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
