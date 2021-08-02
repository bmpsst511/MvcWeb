using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcWeb.Areas.Identity.Data;

[assembly: HostingStartup(typeof(MvcWeb.Areas.Identity.IdentityHostingStartup))]
namespace MvcWeb.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcWebIdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("MvcWebIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MvcWebIdentityDbContext>();
            });
        }
    }
}