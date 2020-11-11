using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
using System.Reflection;
using TodoListReview.Models;
using TodoListReview.Services;

namespace TodoListReview
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
            services.Configure<ItemSettings>(
                Configuration.GetSection(nameof(ItemSettings)));
            services.AddSingleton<IItemSettings>(
                sp => sp.GetRequiredService<IOptions<ItemSettings>>().Value);

            services.AddSingleton<ItemService>();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Swagger addition part 1
            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                var folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var xmlFiles = Directory.GetFiles(folder, "*.xml").ToList();
                xmlFiles.ForEach(x => c.IncludeXmlComments(x));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Swagger addition part 2
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Issue To Do List V1");
            });

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

            app.UseCors("AllowAll");
        }
    }
}
