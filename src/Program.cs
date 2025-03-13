using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FreelaFlowApi.Application.Extensions;
using FreelaFlowApi.Infrastructure.Database;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Infrastructure.Middlewares;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;
using System.Text.Json;
using FreelaFlowApi.Presentation.Swagger;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

try
{
    StartApplication();
}
catch (Exception ex)
{
    Console.WriteLine($"The application failed to start correctly: {ex.Message}");
}

void StartApplication()
{
    ConfigureBuilder(builder);

    ConfigureServices(builder.Services);

    Configure(builder.Build());
}

void ConfigureBuilder(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "allOrigins", policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
    });
}

void ConfigureServices(IServiceCollection services)
{
    services.AddApiVersioning(o =>
    {
        o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        o.ReportApiVersions = true;
    });
    services.AddVersionedApiExplorer(o =>
    {
        o.GroupNameFormat = "'v'VVV";
        o.SubstituteApiVersionInUrl = true;
    });
    services.AddControllers().
        AddJsonOptions(opts =>
        {
            opts.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "FreelaFlowApi", Version = "v1" });

        c.AddSecurityDefinition("Bearer", SwaggerSecurity.SecurityScheme);
        c.AddSecurityRequirement(SwaggerSecurity.SecurityRequirement);

        c.OperationFilter<AddPaginationHeaderParameter>();
    });

    var firebaseConfig = builder.Configuration.GetSection("FirebaseCredentials").Get<Dictionary<string, string>>();

    if (firebaseConfig != null && FirebaseApp.DefaultInstance == null)
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromJson(JsonSerializer.Serialize(firebaseConfig))
        });
    else
        throw new Exception("Firebase credentials not found");

    services.AddDbContext<FreelaFlowApiDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(config.GetConnectionString("FreelaFlowApiDbContext")));

    services.RegisterRepositoriesAndServices();
    services.AddScoped<PaginationDTO>();

    services.AddHttpContextAccessor();
}

void Configure(WebApplication app)
{
    app.UseCors("allOrigins");

    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.UseMiddleware<AuthenticationMiddleware>();

    app.UseMiddleware<PaginationHandlerMiddleware>();

    app.UseMiddleware<CorsHeaderMiddleware>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

