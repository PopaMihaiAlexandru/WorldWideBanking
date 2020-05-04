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
using BankingApp.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataAccess;
using ApplicationLogic.Services.Interfaces;
using ApplicationLogic.Services;
using DataAccess.Repositories;
using ApplicationLogic.Abstractions;

namespace BankingApp
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
            services.AddControllersWithViews();

            services.Add(new ServiceDescriptor(typeof(ILog), new MyConsoleLogger()));

            var connection = @"Server=.\SQLEXPRESS;Database=Bank;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<BankDbContext>
                (options => options.UseSqlServer(connection));
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(connection));


            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IClientRepository, EFClientRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddScoped<ClientService>();
            services.AddScoped<CardService>();
            services.AddScoped<TransactionService>();
            services.AddScoped<AccountService>();

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRazorPages();
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
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
