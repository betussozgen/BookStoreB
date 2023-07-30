using BookStoreB;
using BookStoreB.DBOperations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //.Uygulama aya�a kalkt���ndan initial datan�n in memory DB'ye yaz�lmas� i�in Program.cs i�erisinde configurasyon yap�lmas�
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;   
                DataGenerator.Initialize(services);
            }
            host.Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
