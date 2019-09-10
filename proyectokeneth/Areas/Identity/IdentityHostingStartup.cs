using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using proyectokeneth.Areas.Identity.Data;
using proyectokeneth.Models;

[assembly: HostingStartup(typeof(proyectokeneth.Areas.Identity.IdentityHostingStartup))]
namespace proyectokeneth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddIdentity<proyectokenethUser, IdentityRole>()
                    .AddEntityFrameworkStores<proyectokenethContext>()
                    .AddDefaultUI()
                    //.AddErrorDescriber<CustomPasswordErrorDescribers>()
                    .AddDefaultTokenProviders();
                //services.AddScoped<IUserClaimsPrincipalFactory<PMStudioUser>, PMStudioUserClaimsPrincipalFactory>();
            });

        }
    }
}