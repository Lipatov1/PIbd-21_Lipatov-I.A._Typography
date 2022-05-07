using TypographyContracts.BusinessLogicsContracts;
using Microsoft.Extensions.DependencyInjection;
using TypographyDatabaseImplement.Implements;
using TypographyBusinessLogic.BusinessLogics;
using TypographyContracts.StoragesContracts;
using TypographyBusinessLogic.MailWorker;
using Microsoft.Extensions.Configuration;
using TypographyContracts.BindingModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System;

namespace TypographyRestApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IClientLogic, ClientLogic>();

            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IOrderLogic, OrderLogic>();

            services.AddTransient<IPrintedStorage, PrintedStorage>();
            services.AddTransient<IPrintedLogic, PrintedLogic>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

            services.AddSingleton<AbstractMailWorker, MailKitWorker>();

            services.AddTransient<IWarehouseStorage, WarehouseStorage>();
            services.AddTransient<IWarehouseLogic, WarehouseLogic>();

            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IComponentLogic, ComponentLogic>();

            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TypographyRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TypographyRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            var mailSender = app.ApplicationServices.GetService<AbstractMailWorker>();

            mailSender.MailConfig(new MailConfigBindingModel {
                MailLogin = Configuration?.GetSection("MailLogin")?.Value.ToString(),
                MailPassword = Configuration?.GetSection("MailPassword")?.Value.ToString(),
                SmtpClientHost = Configuration?.GetSection("SmtpClientHost")?.Value.ToString(),
                SmtpClientPort = Convert.ToInt32(Configuration?.GetSection("SmtpClientPort")?.Value.ToString()),
                PopHost = Configuration?.GetSection("PopHost")?.Value.ToString(),
                PopPort = Convert.ToInt32(Configuration?.GetSection("PopPort")?.Value.ToString())
            });
        }
    }
}