using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjectManager.Infrastructure.Contexts;
using ProjectManager.Application.Identity;
using MediatR;
using ProjectManager.Application.Interfaces;
using ProjectManager.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProjectManager.Infrastructure.Messaging;
using ProjectManager.Application.Security.Tokens;
using ProjectManager.Application.Security.Tokens.Providers;

namespace ProjectManager.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _environment;

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000", "http://localhost:3001").WithHeaders("authorization", "content-type"));
            });

            services.AddControllers();

            // Authentication & Authorization

            IConfigurationSection authenticationTokenConfigSection = Configuration.GetSection("AuthenticationTokenConfiguration");
            services.Configure<AuthenticationTokenConfiguration>(authenticationTokenConfigSection);
            AuthenticationTokenConfiguration authenticationTokenConfig = authenticationTokenConfigSection.Get<AuthenticationTokenConfiguration>();

            byte[] key = Encoding.ASCII.GetBytes(authenticationTokenConfig.Secret);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddCookie(IdentityConstants.ApplicationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = authenticationTokenConfig.Issuer,
                    ValidateAudience = true,
                    ValidAudience = authenticationTokenConfig.Audience
                };
            });

            services.AddAuthorization();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Database Access

            services.AddDbContext<ProjectManagerContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(_environment.IsProduction() || _environment.IsDevelopment() ? "DefaultConnection" : "TestConnection"), x => x.MigrationsAssembly("ProjectManager.Infrastructure"));
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // Identity Configuration

            IConfigurationSection accountActionTokenConfigSection = Configuration.GetSection("AccountActionTokenConfiguration");
            services.Configure<AccountActionTokenConfiguration>(accountActionTokenConfigSection);
            AccountActionTokenConfiguration accountActionTokenConfig = accountActionTokenConfigSection.Get<AccountActionTokenConfiguration>();

            string accountActionTokenProvider = "AccountAction";

            services.AddIdentityCore<UserIdentity>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = accountActionTokenProvider;
                options.Tokens.ChangeEmailTokenProvider = accountActionTokenProvider;
                options.Tokens.PasswordResetTokenProvider = accountActionTokenProvider;
            }).AddEntityFrameworkStores<ProjectManagerContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<AccountActionTokenProvider<UserIdentity>>(accountActionTokenProvider);

            services.Configure<AccountActionTokenProviderOptions>(options =>
            {
                options.Secret = accountActionTokenConfig.Secret;
                options.ExpirationInHours = accountActionTokenConfig.ExpirationInHours;
                options.Issuer = accountActionTokenConfig.Issuer;
                options.Audience = accountActionTokenConfig.Audience;
            });

            services.AddScoped<UserManager<UserIdentity>>();
            services.AddScoped<SignInManager<UserIdentity>>();

            // MediatR

            services.AddMediatR(AppDomain.CurrentDomain.Load("ProjectManager.Application"));

            // Email Service

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailSenderConfiguration>(Configuration.GetSection("EmailSenderConfiguration"));
            services.Configure<AppConfirmationUrls>(Configuration.GetSection("EmailConfirmationUrls"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
