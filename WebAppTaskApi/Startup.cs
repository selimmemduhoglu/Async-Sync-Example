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
            ThreadPool.GetAvailableThreads(out workerThread, out threads); // bu bizim uygulamam�zda aktif olarak var olan ka� tane thread oldu�unu bize g�sterecek.
            var theNumberofCoresOnMyComputer =Environment.ProcessorCount; //bilgisayar�m�n �ekirdek say�s�n� ��renmek i�in ; (ama� => belirleyece�imiz thread say�s� bundan az olamaz.)
            var success = ThreadPool.SetMaxThreads(theNumberofCoresOnMyComputer, theNumberofCoresOnMyComputer); // burda da thread say�os�n� belirleyebiliyoruz. (bilgisayar�mda 20 �ekirdek  oldu�u i�in minimum 20 yazmam gerekiyor.)
            
            ThreadPool.GetAvailableThreads(out workerThread, out threads); //bakal�m �imdi ka� olmu�

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
