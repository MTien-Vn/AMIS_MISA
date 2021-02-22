using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Misa.BL.Interface.IDBConnector;
using Misa.BL.Interface.IRepository;
using Misa.BL.Interface.IRepository.IEmployeeRepository;
using Misa.BL.Interface.IService;
using Misa.BL.Interface.IService.IEmployeeService;
using Misa.BL.IService.IEmployeeService;
using Misa.BL.ServiceImp;
using Misa.BL.ServiceImp.EmployeeServiceImp;
using Misa.DL.DBConnectorImp;
using Misa.DL.RepositoryImp;
using Misa.DL.RepositoryImp.EmployeeRepositoryImp;
using Newtonsoft.Json.Serialization;

namespace MISA_AMIS
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
            // add scope dbconnector
            services.AddScoped<IDBConnector, DBConnectorImp>();

            // add scope repository
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepositoryImp<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepositoryImp>();
            services.AddScoped<IEmployeeAccountBankRepository, EmployeeAccountBankRepositoryImp>();
            services.AddScoped<IEmployeeDepartmentRepository, EmployeeDepartmentRepositoryImp>();

            // add scope service
            services.AddScoped(typeof(IBaseService<>), typeof(BaseServiceImp<>));
            services.AddScoped<IEmployeeService, EmployeeServiceImp>();
            services.AddScoped<IEmployeeAccountBankService, EmployeeAccountBankServiceImp>();
            services.AddScoped<IEmployeeDepartmentService, EmployeeDepartmentServiceImp>();

            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MISA_AMIS", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA_AMIS v1"));
            }
                
            app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
