using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppPoNote.Areas.Identity.Data;
using WebAppPoNote.Data;

[assembly: HostingStartup(typeof(WebAppPoNote.Areas.Identity.IdentityHostingStartup))]
namespace WebAppPoNote.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebAppPoNoteDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebAppPoNoteDbContextConnection")));

                services.AddDefaultIdentity<WebAppPoNoteUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<WebAppPoNoteDbContext>();
            });
        }
    }
}