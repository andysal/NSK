using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Nsk.Web.Site.Data;
using Nsk.Web.Site.Models;
using Nsk.Web.Site.Services;
using Nsk.Data.ReadModel;
using Nsk.Commands;
using Nsk.Web.Site.WorkerServices;
using Microsoft.Net.Http.Headers;
using MvcCoreMate.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Identity;
using Nsk.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace Nsk.Web.Site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Add(
                new ServiceDescriptor(
                    typeof(IActionResultExecutor<JsonResult>),
                    Type.GetType("Microsoft.AspNetCore.Mvc.Infrastructure.SystemTextJsonResultExecutor, Microsoft.AspNetCore.Mvc.Core"),
                    ServiceLifetime.Singleton));

            services.AddResponseCaching();
            services.AddResponseCompression();

            services.AddControllersWithViews(options =>
                {
                    // Add XML Content Negotiation
                    options.RespectBrowserAcceptHeader = true;
                    options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                    // Add CSV Output Formatter
                    options.OutputFormatters.Add(new CsvOutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));

                    options.OutputFormatters.Add(new RssOutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("rss", MediaTypeHeaderValue.Parse("application/rss+xml"));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                //.AddNewtonsoftJson(opt =>
                //{
                //    var resolver = opt.SerializerSettings.ContractResolver;
                //    if (resolver != null)
                //    {
                //        var res = resolver as DefaultContractResolver;
                //        res.NamingStrategy = null;  //needed to remove the camelcasing
                //    }
                //})
                .AddRazorRuntimeCompilation();

            services.AddRazorPages();

            // Application Configuration
            services.AddSingleton<IConfiguration>(Configuration);

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            //Infrastructure
            services.AddTransient<IDatabase, Database>();

            //Commands
            services.AddTransient<CartCommands>();

            // WorkerServices
            services.AddTransient<AccountControllerWorkerServices>();
            services.AddTransient<CartControllerWorkerServices>();
            services.AddTransient<CatalogControllerWorkerServices>();
            services.AddTransient<HomeControllerWorkerServices>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseResponseCompression();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "areaRoute",
                //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
                endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "admin",
                    pattern: "admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "my",
                    areaName: "my",
                    pattern: "my/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "mii",
                    areaName: "mii",
                    pattern: "mii/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "ProductsByCategory",
                    pattern: "catalog/c/{categoryId}/{categoryName?}",
                    defaults: new { controller = "Catalog", action = "ProductsByCategory" },
                    constraints: new { categoryId = @"\d+" }
                );

                endpoints.MapControllerRoute(
                    name: "ProductsBySupplier",
                    pattern: "catalog/s/{supplierId}/{supplierName?}",
                    defaults: new { controller = "Catalog", action = "ProductsBySupplier" },
                    constraints: new { supplierId = @"\d+" }
                );

                endpoints.MapControllerRoute(
                    name: "ProductPage",
                    pattern: "product/{productId}/{productName?}",
                    defaults: new { controller = "Catalog", action = "ProductDetail" },
                    constraints: new { productId = @"\d+" }
                );

                endpoints.MapControllerRoute(
                    name: "ProductsRssFeed",
                    pattern: "products/rss",
                    defaults: new { controller = "Catalog", action = "Rss" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
