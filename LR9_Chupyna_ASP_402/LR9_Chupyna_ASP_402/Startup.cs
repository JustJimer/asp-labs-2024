namespace LR9_Chupyna_ASP_402
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IWeatherService, WeatherService>();
            services.AddTransient<IDataPresentationService, DataPresentationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("lastMinuteLabs...");
                });

                endpoints.MapGet("/weather/{region}", async context =>
                {
                    var region = context.Request.RouteValues["region"].ToString();
                    var weatherService = context.RequestServices.GetRequiredService<IWeatherService>();
                    var weather = await weatherService.GetWeather(region);
                    await context.Response.WriteAsync($"Current temperature in {region}: {weather.Main.Temp}°C");
                });

                endpoints.MapGet("/data", async context =>
                {
                    var dataPresentationService = context.RequestServices.GetRequiredService<IDataPresentationService>();
                    var dataObjects = new[]
                    {
                        new DataObject { ID = 1, Name = "lastMinuteLabs", Price = 10.33 },
                        new DataObject { ID = 2, Name = "lastSecondLabs", Price = 20.22 }
                    };
                    var htmlTable = dataPresentationService.GetDataTable(dataObjects);
                    await context.Response.WriteAsync(htmlTable);
                });
            });
        }
    }
}
