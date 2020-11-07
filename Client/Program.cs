using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Authorization;
using Tewr.Blazor.FileReader;

namespace GSOClient.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddAntDesign();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddFileReaderService(options =>
            {
                options.UseWasmSharedBuffer = true;
            });

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:30")
            });

            await builder.Build().RunAsync();

            _ = new JwtPayload();
        }
    }
}
