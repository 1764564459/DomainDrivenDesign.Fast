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
            //ע�����
            services.RegisterService();

            //ע�빤����Ԫ
            services.AddScoped<IUnitOfWork, UnitOfWork<StudyDbContext>>();

            //ע���н���ģʽ
            services.AddScoped<IMediatorHandler, InMemoryMediator>();

            //�н���ģʽ
            services.AddMediatR(typeof(Startup));

            //����
            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>,StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();

            //�¼�
            services.AddScoped<INotificationHandler<RegisterStudentEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<UpdateStudentEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<RemoveStudentEvent>, StudentEventHandler>();

            //�����¼�֪ͨ
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
