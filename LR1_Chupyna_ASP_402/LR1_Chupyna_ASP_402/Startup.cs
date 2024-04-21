namespace LR1_Chupyna_ASP_402
{
    public class Startup
    {
        public class Company
        {
            public string Name { get; set; }
            public string Founder { get; set; }
            public int YearFounded { get; set; }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var company = new Company
                    {
                        Name = "lastMinuteLabs INC",
                        Founder = "Valerii Chupyna",
                        YearFounded = 2024,
                    };

                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Company: {company.Name} " +
                                                      $"\nFounder & CEO: {company.Founder} " +
                                                      $"\nFounded: {company.YearFounded}");
                });

                endpoints.MapGet("/random", async context =>
                {
                    var random = new Random();
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync($"Random number: {random.Next(0, 101)}");
                });
            });
        }
    }
}
