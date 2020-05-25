using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Hahn.ApplicatonProcess.May2020.Data.Base;
using Hahn.ApplicatonProcess.May2020.Data.DbContext;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.May2020.Domain.Managers;
using Hahn.ApplicatonProcess.May2020.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicatonProcess.May2020.Api
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
            services.AddMvc().AddFluentValidation();
            services.AddTransient<IValidationManager, ValidationManager>();
            services.AddTransient<IApplicantManager, ApplicantManager>();
            services.AddTransient<IGenericRepository<Applicant>, GenericRepository<Applicant>>();
            services.AddTransient<ApplicantRepository>();
            services.AddDbContext<HahnDbContext>(options => options.UseInMemoryDatabase("HahnDbContext"));
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
        }
    }
}
