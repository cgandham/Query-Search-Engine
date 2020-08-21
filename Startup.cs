
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(elastic.Startup))]
namespace elastic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
           // ElasticClient.Initialize();
        }
    }
}
