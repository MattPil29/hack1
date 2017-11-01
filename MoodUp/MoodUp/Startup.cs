using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoodUp.Startup))]
namespace MoodUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
