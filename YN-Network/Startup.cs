using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using YN_Network.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YN_Network.Areas.Search.Services;
using YN_Network.Areas.Jokes.Services;
using YN_Network.Areas.Comics.Services;
using YN_Network.Areas.News.Services;
using YN_Network.Areas.Questions.Services;

namespace YN_Network
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddHttpClient();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddScoped<IQueryService, QueryService>();
            services.AddScoped<IJokesService, JokesService>();
            services.AddScoped<IComicService, ComicService>();
            services.AddScoped<INewsService, RssNewsService>();
            services.AddScoped<IQuestionService, QuestionService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "Questions",
                   defaults: new { controller = "Home", action = "Index" },
                   pattern: "{area:exists}/{action=Index}/{id?}/{slug?}"
                 );
                endpoints.MapControllerRoute(
                    name: "Search",
                    pattern: "{area:exists}/{controller=Query}/{action=Index}/{query?}"
                  );
                endpoints.MapControllerRoute(
                    name: "Jokes",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{type?}"
                    );
                endpoints.MapControllerRoute(
                    name: "News",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{category?}"
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });
        }
    }
}
