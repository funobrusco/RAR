using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RAR.API.Service;
using RAR.API.Utility;
using RAR.DAL.Model.Tabella;
using RAR.DAL.Repository;
using RAR.Service;
using System;
using System.Text;

namespace RAR.API
{
    public class Startup
    {
        private IWritableOptions<ConnectionStrings> _options;
        const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        const string StringConnectionEV = "RAR_SQLCONNSTR_EQUITALIADB";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()//.WithOrigins("https://localhost:44303")
                         .AllowAnyMethod()
                         .AllowAnyHeader();
                });
            });

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureWritable<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            #region JWT
            // configure strongly typed settings objects
            //var appSettingsSection = Configuration.GetSection("AppSettings");
            //services.Configure<AppSettings>(appSettingsSection);

            // jwt authentication
            //var appSettings = appSettingsSection.Get<AppSettings>();
            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(jwtOptions =>
            //{
            //    jwtOptions.RequireHttpsMetadata = false;
            //    jwtOptions.SaveToken = true;
            //    jwtOptions.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});
            #endregion JWT

            services.AddScoped<IQueryManagerRepository, QueryManagerRepository>();
            services.AddScoped<IQueryManagerService, QueryManagerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IQueryManagerService, QueryManagerService>();
            services.AddScoped<IQueryManagerRepository, QueryManagerRepository>();
            services.AddScoped<IDispaccioRepository, DispaccioRepository>();
            services.AddScoped<ICartolinaRepository, CartolinaRepository>();
            services.AddScoped<INewDispaccioInRepository, NewDispaccioInRepository>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IDispaccioService, DispaccioService>();
            services.AddScoped<ICartolinaService, CartolinaService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IStoricoCartelleService, StoricoCartelleService>();
            string connectionString = ProcessStringConnection();
            services.AddDbContext<RARContext>(optionsDb => optionsDb.UseSqlServer(connectionString));
        }

        private string ProcessStringConnection()
        {
            var connectionString = Configuration.GetConnectionString("equitaliadb");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = Environment.GetEnvironmentVariable(StringConnectionEV, EnvironmentVariableTarget.Machine);
                connectionString = EncryptUtility.Decrypt(connectionString);
            }
            else
            {
                Environment.SetEnvironmentVariable(StringConnectionEV, EncryptUtility.Encrypt(connectionString), EnvironmentVariableTarget.Machine);
            }

            return connectionString;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IWritableOptions<ConnectionStrings> options 
            /*IServiceCollection services*/)
        {
            _options = options;
            _options.Update(opt =>
            {
                opt.equitaliadb = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseAuthentication();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
        }
    }
}
