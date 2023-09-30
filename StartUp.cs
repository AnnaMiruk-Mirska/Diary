using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diary.App_Start.StartUp))]
namespace Diary.App_Start
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}