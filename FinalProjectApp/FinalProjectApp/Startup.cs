using JobsForAll.Contracts;
using JobsForAll.Helpers;
using JobsForAll.Library.Models;
using JobsForAll.Services;
using JobsForAll.SqlDatabase;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace JobsForAll
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetIsOriginAllowed(_ => true));
            });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddIdentityServerJwt()
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = Configuration["Jwt:Site"],
                      ValidIssuer = Configuration["Jwt:Site"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SigningKey"])),
                  };
              });

            services.AddIdentityServerBuilder();
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            Bootstrapper.SetUp(services, connectionString);

            services.AddRazorPages();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinalProjectApp", Version = "v1" });
            });
            services.AddMvc();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJobsService, JobsService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICommentService, CommentService>();

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalProjectApp v1"));
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMiddleware<JwtMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MessageHub>("/chatsocket");
            });
        }

        //

        private IConfiguration Configuration { get; }
    }
}
