
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;
using SportAppNet.Service.Service;
using SportAppNet.Tool;

namespace SportAppNet
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
            services.AddCors();
            services.AddControllers();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.AddDbContext<Context>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));


            //mapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                //mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();   
           

            //DI
            services.AddSingleton(mapper);       
            services.AddControllers().AddNewtonsoftJson();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmailService, EmailService>();

            //JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

        }
  
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
