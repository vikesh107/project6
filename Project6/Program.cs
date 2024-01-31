using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Project6.EnttiyFrameworkCore.Models;
using System.Text;

namespace Project6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("vikesh123@12345678901234567890ABCD")),
                    ValidateAudience = true, 
                    ValidAudience = "https://localhost:44396",
                    ValidateIssuer = true,
                    ValidIssuer = "https://localhost:44396"

                };
            });


            builder.Services.AddSwaggerGen();
            //builder.Services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

            //    // Configure JWT Bearer token authentication
            //    var securityScheme = new OpenApiSecurityScheme
            //    {
            //        Name = "Authorization",
            //        Description = "JWT Authorization header using the Bearer scheme",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.ApiKey,
            //        Scheme = "Bearer"
            //    };

            //    c.AddSecurityDefinition("Bearer", securityScheme);
            //    var securityRequirement = new OpenApiSecurityRequirement
            //    {
            //        { securityScheme, new[] { "Bearer" } }
            //    };
            //    c.AddSecurityRequirement(securityRequirement);
            //});
            builder.Services.AddDbContext<MyDbContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //Add for this Autherization And Authentication by Token Bearer.
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}