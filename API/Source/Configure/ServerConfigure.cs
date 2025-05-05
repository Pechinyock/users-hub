using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace Me.UserHub;

internal static class ServerConfigure
{
    internal static void ConfigureServer(this IWebHostBuilder builder)
    {
        builder.ConfigureKestrel(options =>
        {
             options.Listen(IPAddress.Any, 5000, listenOptions =>
             {
                 listenOptions.Protocols = HttpProtocols.Http2;
             });

             options.Listen(IPAddress.Any, 5001, listenOptions =>
             {
                 listenOptions.UseHttps();
                 listenOptions.Protocols = HttpProtocols.Http2;
             });
        });
    }
}
