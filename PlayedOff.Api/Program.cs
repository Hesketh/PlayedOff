using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using PlayedOff.Api.Filters.Operation;
using PlayedOff.Domain.Extensions;
using PlayedOff.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisDistributedCache(connectionName: "cache");

builder.Services.AddProblemDetails();
builder.Services.AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddPlayedOffServices();

var adOptionsKey = "AzureAd";
var adOptions = new MicrosoftIdentityOptions();
builder.Configuration.Bind(adOptionsKey, adOptions);
builder.Services.AddSingleton(adOptions);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Argued Call", Version = "1" });
    options.CustomSchemaIds(x => x.FullName);
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"{adOptions.Instance}{adOptions.TenantId}/oauth2/v2.0/authorize"),
                TokenUrl = new Uri($"{adOptions.Instance}{adOptions.TenantId}/oauth2/v2.0/token"),
                Scopes = adOptions.Scope.ToDictionary(x => x)
            }
        }
    });
    options.OperationFilter<AuthResponsesOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
        {
            builder.Configuration.Bind(adOptionsKey, options);
            options.TokenValidationParameters.NameClaimType = "name";
        },
        options => { builder.Configuration.Bind(adOptionsKey, options); });


var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(uiOptions =>
    {
        uiOptions.OAuthClientId(adOptions.ClientId);
        uiOptions.OAuthClientSecret(adOptions.ClientSecret);
        uiOptions.OAuthScopes(adOptions.Scope.ToArray());
        uiOptions.OAuthUsePkce();
    });
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
