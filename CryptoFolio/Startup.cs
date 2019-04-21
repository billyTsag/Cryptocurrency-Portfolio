using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CryptoFolio.Startup))]
namespace CryptoFolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
