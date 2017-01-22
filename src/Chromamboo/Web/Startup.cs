using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Chromamboo.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
          

        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
    }
}