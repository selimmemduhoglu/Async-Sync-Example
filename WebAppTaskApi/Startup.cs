using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAppTaskApi
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


            int workerThread ,  threads;
            ThreadPool.GetAvailableThreads(out workerThread, out threads); // bu bizim uygulamamýzda aktif olarak var olan kaç tane thread olduðunu bize gösterecek.
            var theNumberofCoresOnMyComputer =Environment.ProcessorCount; //bilgisayarýmýn çekirdek sayýsýný öðrenmek için ; (amaç => belirleyeceðimiz thread sayýsý bundan az olamaz.)
            var success = ThreadPool.SetMaxThreads(theNumberofCoresOnMyComputer, theNumberofCoresOnMyComputer); // burda da thread sayýosýný belirleyebiliyoruz. (bilgisayarýmda 20 çekirdek  olduðu için minimum 20 yazmam gerekiyor.)
            
            ThreadPool.GetAvailableThreads(out workerThread, out threads); //bakalým þimdi kaç olmuþ

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
