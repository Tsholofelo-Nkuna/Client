using ClientUI.Web.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ClientUI.Web.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
          
            await builder.Build().RunAsync();
        }
    }
}
