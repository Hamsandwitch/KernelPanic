using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingList_Team2_Master.Startup))]
namespace ShoppingList_Team2_Master
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
