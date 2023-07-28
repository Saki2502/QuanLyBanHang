using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBHNguyenDangTuyetNhi.Startup))]
namespace QLBHNguyenDangTuyetNhi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
