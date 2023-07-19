using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(FilterExecutionOrder.OwinStartup))]
namespace FilterExecutionOrder
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new System.Web.Http.HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
            app.UseWebApi(config);
        }
    }
}
