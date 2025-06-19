// WebApi/Program.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebApi.Extensions;
using WebApi.Filters;
using WebApi.Middleware;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});

// Configuración de versionamiento
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Configuración de Swagger
builder.Services.AddSwaggerConfiguration();

// Registrar dependencias de otras capas
builder.Services.AddApplication(); // Capa Application
//builder.Services.AddDomain();      // Capa Domain

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Configuración de logging
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configuración del pipeline HTTP
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

if (app.Environment.IsDevelopment())
{
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();