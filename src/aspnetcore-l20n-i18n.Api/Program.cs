using aspnetcore_l20n_i18n.Api.Auth.Extensions;
using aspnetcore_l20n_i18n.Infrastructure.Repository.Extensions;
using aspnetcore_l20n_i18n.Services.Extensions;
using Hellang.Middleware.ProblemDetails;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Development,
});

SerilogExtensions.AddSerilogApi(builder.Configuration);
builder.Host.UseSerilog(Log.Logger);

// Add services to the container.
builder.Services.AddProblemDetails(setup => setup.IncludeExceptionDetails = (ctx, env) =>
Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ||
Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Staging");

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Protected API", Version = "v1" });
});

builder.Services.AddRepositoryInfrastructure(builder.Configuration)
    .AddServices(builder.Configuration)
    .Configure<RouteOptions>(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configuration
app.UseProblemDetails();
app.UseRouting();

app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyHeader();
    x.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage()
        .UseDatabaseExceptionFilter()
        .UseSwagger()
        .UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger", "Corinthians API V1");
        });
}
else
{
    app.UseExceptionHandler("/Error")
        .UseHsts();
}

app.UseRequestLocalization(options => options.SetDefaultCulture(CultureInfo.CurrentCulture.Name)
.AddSupportedCultures("pt-BR", "en-GB")
.AddSupportedUICultures("pt-BR", "en-US"));

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.InitializeAndRunAsync();