using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Extensions;
using Swashbuckle.Application;

#pragma warning disable 1591

[assembly: OwinStartup(typeof(AppNetServer.Startup))]
namespace AppNetServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var myProvider = new AuthorizationServerProvider();
            var config = new HttpConfiguration();

            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };

            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
             );
            config.EnableSwagger(c =>
            {
                c.IncludeXmlComments("docs.xml");
                c.SingleApiVersion("1.0", "Owin Swashbuckle Demo");
            }).EnableSwaggerUi();

            app.UseStageMarker(PipelineStage.MapHandler);
            app.UseWebApi(config);
        }

    }
}