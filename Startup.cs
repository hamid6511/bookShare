using bookShare.Database;
using bookShare.Services;
using Microsoft.EntityFrameworkCore;

namespace bookShare
{
    public class Startup
    {
        public string ConnectionString {  get; set; }
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
            ConnectionString = Configuration.GetConnectionString("DefaultConnectionString");// Connection Db

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(ConnectionString));
            services.AddTransient<UsersServices>();
            services.AddTransient<BooksServices>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "bookShare", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
               // app.UseSwaggerUI(c => c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "bookShare v1"));
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AppDbInitializer.Seed(app);
        }
    }
}
