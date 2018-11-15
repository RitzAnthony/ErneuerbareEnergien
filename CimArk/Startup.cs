using System.Data.Entity;
using Microsoft.Owin;
using Owin;
using BLL;

[assembly: OwinStartupAttribute(typeof(CimArk.Startup))]
namespace CimArk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            BLL.Startup.SetupDatabase();
        }
    }
}
