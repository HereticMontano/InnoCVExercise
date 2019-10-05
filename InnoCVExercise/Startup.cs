﻿using AutoMapper;
using InnoCVExercise.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using InnoCVExercise.DataLayer;
using InnoCVExercise.DataLayer.Mock;
using InnoCVExercise.StartupService;

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

            //Inyections
            services.AddSingleton(prop => { return new MapperConfiguration(cfg => { cfg.AddProfile<MappingEntityDTOModel>(); }).CreateMapper(); });
            services.AddTransient(prop =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseInMemoryDatabase("DataBase");
                return new Context(optionsBuilder.Options);
            });
            services.AddTransient(prop => new Manager(prop.GetRequiredService<Context>(), prop.GetRequiredService<IMapper>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
                
                //Put some data in memory            
                DataGenerator.Initialize(app.ApplicationServices.GetRequiredService<Context>());
            }

            app.UseMvc();
        }
    }   
}
