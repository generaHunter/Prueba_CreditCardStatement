using Azure.Identity;
using CreditCardStatement.Api;
using CreditCardStatement.Api.Middlewares;
using CreditCardStatement.Application;
using CreditCardStatement.Common;
using CreditCardStatement.External;
using CreditCardStatement.Persistence;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);


var keyVaultUrl = builder.Configuration["keyVaultUrl"] ?? string.Empty;


if (keyVaultUrl.Length > 0)
{
    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
    {
        string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
        string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
        string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

         var tokenCrendetials = new ClientSecretCredential(tenantId, clientId, clientSecret);

        builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCrendetials);
    }
    else
    {
        builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
    }

}

builder.Services.AddHealthChecks()
    //.AddCheck<DatabaseHealthCheck>("Database");
    .AddSqlServer(builder.Configuration["SQLConnectionStrings"]!);

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersitence(builder.Configuration);

builder.Services.AddControllers();




var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.

app.MapHealthChecks("/_health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapControllers();

app.Run();
