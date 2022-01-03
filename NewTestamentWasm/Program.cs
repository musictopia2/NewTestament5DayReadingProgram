using BasicBlazorLibrary.Helpers; //not common enough to put under globals for now.
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NewTestamentWasm;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.RegisterBlazorBeginningClasses();

await builder.Build().RunAsync();
