using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InventoryTool.Startup))]
namespace InventoryTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
