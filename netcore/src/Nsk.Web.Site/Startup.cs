using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

namespace Nsk.Web.Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddResponseCaching();
            services.AddResponseCompression();

            services.AddMvc(options =>
                {
                    // Add XML Content Negotiation
                    options.RespectBrowserAcceptHeader = true;
                    options.InputFormatters.Add(new XmlSerializerInputFormatter());
                    options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                    // Add CSV Output Formatter
                    options.OutputFormatters.Add(new CsvOutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));

                    options.OutputFormatters.Add(new RssOutputFormatter());
                    options.FormatterMappings.SetMediaTypeMappingForFormat("rss", MediaTypeHeaderValue.Parse("application/rss+xml"));
                })
                .AddJsonOptions(opt =>
                {
                    var resolver = opt.SerializerSettings.ContractResolver;
                    if (resolver != null)
                    {
                        var res = resolver as DefaultContractResolver;
                        res.NamingStrategy = null;  //needed to remove the camelcasing
                    }
                });

            // Application Configuration
            services.AddSingleton<IConfigurationRoot>(Configuration);

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseResponseCompression();

            app.UseStaticFiles();
            
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "default",
                //    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "ProductsByCategory",
                    template: "catalog/c/{categoryId}/{categoryName?}",
                    defaults: new { controller = "Catalog", action = "ProductsByCategory" },
                    constraints: new { categoryId = @"\d+" }
                );

                routes.MapRoute(
                    name: "ProductsBySupplier",
                    template: "catalog/s/{supplierId}/{supplierName?}",
                    defaults: new { controller = "Catalog", action = "ProductsBySupplier" },
                    constraints: new { supplierId = @"\d+" }
                );

                routes.MapRoute(
                    name: "ProductPage",
                    template: "product/{productId}/{productName?}",
                    defaults: new { controller = "Catalog", action = "ProductDetail" },
                    constraints: new { productId = @"\d+" }
                );

                routes.MapRoute(
                    name: "ProductsRssFeed",
                    template: "products/rss",
                    defaults: new { controller = "Catalog", action = "Rss" }
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
