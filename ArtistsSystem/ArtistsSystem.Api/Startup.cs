using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ArtistsSystem.Api.Startup))]

namespace ArtistsSystem.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
