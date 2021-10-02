using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PracticalTest.Domain;
using PracticalTest.ExcelService.Service;
using PracticalTest.ExcelService.Service.Interface;
using PracticalTest.Repositoy;
using PracticalTest.Repositoy.Repositories;
using PracticalTest.Repositoy.Repositories.Interfaces;
using PracticalTest.Service;
using PracticalTest.Service.Interfaces;
using PracticalTestExecl.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTestExecl
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicaitonDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            //services.Configure<ExcelSheet>(configuration.GetSection("ExcelSheet"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();

            services.AddScoped<IEthnicityRepository, EthnicityRepository>();
            services.AddScoped<IEthnicityService, EthnicityService>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IExcelService, ExcelService>();


            services.AddRazorPages();
            services.AddControllers();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

        }
    }
}
