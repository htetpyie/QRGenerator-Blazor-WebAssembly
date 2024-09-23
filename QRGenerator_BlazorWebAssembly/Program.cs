using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using QRGenerator_BlazorWebAssembly;
using QRGenerator_BlazorWebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<QRCodeService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// builder.Services.AddMsalAuthentication(options =>
// {
// 	builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
// });

await builder.Build().RunAsync();
