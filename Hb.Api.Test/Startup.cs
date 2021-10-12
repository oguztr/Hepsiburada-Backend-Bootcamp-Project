using HB.Api;
using HB.Application;
using HB.Domain.Entities;
using HB.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.Api.Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration) { }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationModuleTest(Configuration);
            services.AddControllers();
        }
        public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<HbContext>();

            AddTestData(context);

            base.Configure(app, env);
        }

        private void AddTestData(HbContext context)
        {
            for(int i = 0; i<10; i++)
            {
                Firm firm = new();
                firm.Address = $"Company {i}";
                firm.Email = $"Email {i}";
                firm.Name = $"Name {i}";
                firm.ManagerName = $"Manager {i}";

                context.Firms.Add(firm);
                context.SaveChanges();
                for(int j =0; j<6; j++)
                {
                    Order order = new();
                    order.TotalAmount = 125;
                    order.FirmId = firm.Id;
                    context.Orders.Add(order);
                }
                context.SaveChanges();
            }
        }
    }
}
