using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Constants;
using DataAccess.DataContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Presentation.Extensions.Configuration;
using Presentation.Jwt;

namespace Presentation.Extensions;

public static class Extension
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IIdentityRepository, IdentityRepository>();

        services.AddScoped(typeof(MongoDbContext));
    }

    public static void AddBearerConfig(this IServiceCollection services)
    {
        const string jwtSecret = Key.JwtSecret;
        services
            .AddAuthentication(opt => opt.AuthOptionsConfig())
            .AddJwtBearer(opt => opt.BearerOptionsConfig(jwtSecret));

        services.AddAuthorization(opt => opt.AuthorizationConfig());
        services.AddHttpContextAccessor();
    }

    public static void AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddSwaggerGen(opt =>
        {
            opt.AddSwaggerAuth();

            // solve conflict records
            opt.CustomSchemaIds(x => x.FullName);
        });
    }

    public static void UseSwaggerConfig(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
            return;

        app.UseDeveloperExceptionPage();
        app.UseSwagger();
    }

    public static void AddCorsAllowAll(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                }
            );
        });
    }
}
