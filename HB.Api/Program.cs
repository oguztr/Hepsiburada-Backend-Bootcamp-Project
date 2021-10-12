using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace HB.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Seq("http://localhost:5341")
             .MinimumLevel.Information()
             .CreateLogger();
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host Terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
