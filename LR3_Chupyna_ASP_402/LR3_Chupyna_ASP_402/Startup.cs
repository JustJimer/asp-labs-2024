namespace LR3_Chupyna_ASP_402
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<CalcService>();
            services.AddTransient<TimeOfDayService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var timeOfDayService = context.RequestServices.GetRequiredService<TimeOfDayService>();
                    var message = timeOfDayService.GetTimeOfDayMessage();
                    await context.Response.WriteAsync($"Current time of day: {message}");
                });

                endpoints.MapControllers();
            });
        }
    }
}
