using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InnoCVExercise
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
            services.AddMvc();                  
            var configMapper = new MapperConfiguration(cfg => cfg.AddMaps(new[] {
                                                                    "InnoCVExercise",
                                                                    "InnoCVExercise.Service"
                                                                }));
            services.AddSingleton(configMapper.CreateMapper());
            

            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("autofac.json");
            
            //var builder = new ContainerBuilder();
            //builder.RegisterModule(configBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }   
}
