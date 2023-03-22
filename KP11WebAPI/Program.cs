using System.Text;
using FluentValidation.AspNetCore;
using KP11.Integration.Models;
using KP11WebAPI;
using KP11WebAPI.APIs;
using KP11WebAPI.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);
WebApplication app = builder.Build();

Configure(app);

IEnumerable<IAPI> apis = app.Services.GetServices<IAPI>();
foreach (IAPI api in apis)
{
    if (api is null)
        throw new InvalidProgramException("API couldn't be found!");
    api.Register(app);
}

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.ResolveConflictingActions(api => api.First());
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    });
    services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserModel>());
    services.AddDbContext<ManualDb>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
    });
    services.AddScoped<IManualRepository, ManualRepository>();
    services.AddScoped<ISubjectRepository, SubjectRepository>();
    services.AddScoped<IProfessorRepository, ProfessorRepository>();
    
    services.AddSingleton<ITokenService>(new TokenService());
    services.AddSingleton<IUserRepository>(new UserRepository());
    services.AddAuthorization();
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
            };
        });
    
    services.AddTransient<IAPI, AuthAPI>();
    services.AddTransient<IAPI, ManualAPI>();
    services.AddTransient<IAPI, SubjectAPI>();
    services.AddTransient<IAPI, ProfessorAPI>();
}

void Configure(WebApplication app)
{
    app.UseAuthentication();
    app.UseAuthorization();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        using var scope = app.Services.CreateScope();
        ManualDb manualDb = scope.ServiceProvider.GetRequiredService<ManualDb>();
        manualDb.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();
}