using Cookware.Data;
using Cookware.Models.Interfaces;
using Cookware.Models.Services;
using Cookware.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Cookware.Models.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Cookware
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireLowercase = true;
            }

            )
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<CookwareDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBe21ToPurchase", policy => policy.Requirements.Add(new MinAgeRequirement(21)));
                options.AddPolicy("FavoriteLanguage", policy => policy.RequireClaim("FavoriteLanguage"));
                options.AddPolicy("SchoolEmail", policy => policy.Requirements.Add(new SchoolEmailHandler()));
                options.AddPolicy("AdminAccess", policy => policy.RequireRole(UserRoles.Admin));
            });

            services.AddTransient<IProducts, ProductService>();
            services.AddTransient<IBasketItem, BasketItemService>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IOrder, OrderService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
