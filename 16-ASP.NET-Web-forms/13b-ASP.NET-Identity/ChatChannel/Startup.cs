using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatChannel.Startup))]
namespace ChatChannel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
