using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PlayedOff.Api.Filters.Operation;

public class AuthResponsesOperationFilter(MicrosoftIdentityOptions identityOptions) : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var allowAnonAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AllowAnonymousAttribute>() ?? [];

        if (allowAnonAttributes.Any())
            return;

        var authAttributes = context.MethodInfo.DeclaringType?.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>() ?? [];

        if (authAttributes.Any())
        {
            var securityRequirement = new OpenApiSecurityRequirement
            {  
                {  
                    new OpenApiSecurityScheme {  
                        Reference = new OpenApiReference {  
                            Type = ReferenceType.SecurityScheme,  
                            Id = "oauth2"  
                        },  
                        Scheme = "oauth2",  
                        Name = "oauth2",  
                        In = ParameterLocation.Header  
                    },  
                    identityOptions.Scope.ToList()  
                }  
            };  
            operation.Security = new List<OpenApiSecurityRequirement> { securityRequirement };

            if (!operation.Responses.ContainsKey("401"))
                operation.Responses.Add("401", new OpenApiResponse { Description = "Unauthorized" });

            if (!operation.Responses.ContainsKey("403"))
                operation.Responses.Add("403", new OpenApiResponse { Description = "Forbidden" });
        }
    }
}