namespace LR2_Chupyna_ASP_402
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                        .AddJsonFile("appset.json")
                        .AddXmlFile("appsettings.xml")
                        .AddIniFile("appsettings.ini")

                        .AddJsonFile("personal.json");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
