using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

using PWA;
using Services;
using PWA.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add authentication state provider
builder.Services.AddAuthorizationCore();

// Add auth
builder.Services.AddApiAuthorization();

// Add authentication state provider
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.AddScoped<CookieHandler>();

// Add HttpClient factory
builder.Services.AddHttpClient();

// Configure named HttpClient with auth handler
builder.Services.AddHttpClient("API", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Register scoped HttpClient
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IIndexedDbService, IndexedDbService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
