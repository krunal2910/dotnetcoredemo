
using DotNetCorePractical.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DotNetCorePractical.Areas.Identity.IdentityHostingStartup))]
namespace DotNetCorePractical.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DotNetCorePracticalContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DotNetCorePracticalContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DotNetCorePracticalContext>();
            });
        }
    }
}