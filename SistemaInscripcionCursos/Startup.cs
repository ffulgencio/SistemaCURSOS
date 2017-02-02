using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaInscripcionCursos.Startup))]
namespace SistemaInscripcionCursos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
