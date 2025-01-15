using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using PWA;
using Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add HttpClient factory
builder.Services.AddHttpClient();

// Add auth
builder.Services.AddApiAuthorization();

// Configure named HttpClient with auth handler
builder.Services.AddHttpClient("API", client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Register scoped HttpClient
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("API"));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IIndexedDbService, IndexedDbService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

await builder.Build().RunAsync();
