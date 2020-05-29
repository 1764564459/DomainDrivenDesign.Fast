using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainDrivenDesign.Domain.CommandHandlers;
using DomainDrivenDesign.Domain.Commands.Student;
using DomainDrivenDesign.Domain.Core.Bus;
using DomainDrivenDesign.Domain.Core.NotificationHandler;
using DomainDrivenDesign.Domain.Core.Notifications;
using DomainDrivenDesign.Domain.EventHandler;
using DomainDrivenDesign.Domain.Events.Student;
using DomainDrivenDesign.Domain.Interface;
using DomainDrivenDesign.Infrastructure.Bus;
using DomainDrivenDesign.Infrastructure.DbContexts;
using DomainDrivenDesign.Infrastructure.UnitOfWork;
using DomainDrivenDesign.Web.Core.Extension;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DomainDrivenDesign.Web
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
            services.AddControllersWithViews();
            //注册服务
            services.RegisterService();

            //注入工作单元
            services.AddScoped<IUnitOfWork, UnitOfWork<StudyDbContext>>();

            //注入中介者模式
            services.AddScoped<IMediatorHandler, InMemoryMediator>();

            //中介者模式
            services.AddMediatR(typeof(Startup));

            //命令
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>,StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();

            //事件
            services.AddScoped<INotificationHandler<RegisterStudentEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<UpdateStudentEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<RemoveStudentEvent>, StudentEventHandler>();

            //领域事件通知
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
