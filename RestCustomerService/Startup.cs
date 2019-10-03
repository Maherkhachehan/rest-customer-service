using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RestCustomerService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // MiddleWare classic
            services.AddCors();

            // MiddleWare with policy
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://example.com"));

            //    options.AddPolicy("AllowAnyOrigin",
            //        builder => builder.AllowAnyOrigin());

            //    options.AddPolicy("AllowAnyOriginGetPost",
            //        builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            //});

            // MVC policy
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://example.com"));

            //    options.AddPolicy("AllowAnyOrigin",
            //        builder => builder.AllowAnyOrigin());

            //    options.AddPolicy("AllowAnyOriginGetPost",
            //        builder => builder.AllowAnyOrigin().WithMethods("GET", "POST"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // MiddleWare classic
            app.UseCors(options =>
                {
                    options.AllowAnyOrigin().AllowAnyMethod();
                });

            // MiddeWare with policy
            //app.UseCors("AllowAnyOrigin");
        }
    }
}
