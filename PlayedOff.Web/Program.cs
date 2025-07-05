using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlayedOff.Api.Client.Extensions;
using PlayedOff.Web;
using PlayedOff.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMsalAuthentication(options
    =>
{
    builder.Configuration.Bind("ProviderOptions", options.ProviderOptions);
    options.ProviderOptions.Cache.StoreAuthStateInCookie = true;
    options.ProviderOptions.Cache.CacheLocation = "localStorage";
});

builder.Services.AddPlayedOffApiClients<BearerTokenHttpMessageHandler>(
    new Uri(builder.Configuration["Api"] ?? throw new InvalidOperationException("No Api url specified")));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
