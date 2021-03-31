using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dealership_api_dotnet.Models;
using Microsoft.Extensions.Options;
using dealership_api_dotnet.Services;


namespace my_new_app
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddControllers().AddNewtonsoftJson(o => o.UseMemberCasing());
            services.Configure<DealershipDatabaseSettings>(
                Configuration.GetSection(nameof(DealershipDatabaseSettings))
            );

            services.AddSwaggerGen();
            services.AddSingleton<IDealershipDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DealershipDatabaseSettings>>().Value);

            services.AddSingleton<InventoryService>();
            services.AddSingleton<UsersService>();
            services.AddSingleton<CarRulesService>();
            services.AddTransient<MessagesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dealership API V1");
                }
            );

            app.UseRouting();
            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{action=Get}/{id?}");
                }
            );
        }
    }
}
