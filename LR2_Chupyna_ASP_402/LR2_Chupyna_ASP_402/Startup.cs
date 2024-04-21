namespace LR2_Chupyna_ASP_402
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<CompanyService>();
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
                    var companyService = context.RequestServices.GetService<CompanyService>();

                    await context.Response.WriteAsync($"most employees: {companyService.GetCompanyWithMostEmployees()}\n");

                    await context.Response.WriteAsync($"\n\nname: {Configuration["name"]}\n");
                    await context.Response.WriteAsync($"favorite fruit: {Configuration["fruit"]}\n");
                    await context.Response.WriteAsync($"born in: {Configuration["city"]}\n");
                });
            });
        }
    }

    public class Company
    {
        public string Name { get; set; }
        public int Employees { get; set; }
    }

    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetCompanyWithMostEmployees()
        {
            var companies = new List<Company>();

            companies.AddRange(_configuration.GetSection("Companies").Get<List<Company>>());
            companies.AddRange(_configuration.GetSection("Companies").Get<List<Company>>());
            companies.AddRange(_configuration.GetSection("Companies").Get<List<Company>>());

            var companyWithMostEmployees = companies.OrderByDescending(c => c.Employees).FirstOrDefault();

            return companyWithMostEmployees != null ? companyWithMostEmployees.Name : "no company";
        }
    }
}
