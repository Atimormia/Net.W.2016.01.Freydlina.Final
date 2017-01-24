using Microsoft.Owin;
using Owin;
using QuestionsApp.WebUI;

[assembly: OwinStartup(typeof(Startup))]
namespace QuestionsApp.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
