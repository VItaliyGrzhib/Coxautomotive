using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
             //   .UseContentRoot(AppContext.BaseDirectory)
                .Build()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
