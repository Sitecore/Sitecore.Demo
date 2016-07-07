namespace Sitecore.Feature.Brochure.Pipelines
{
  using System.Web.Mvc;
  using System.Web.Routing;
  using Sitecore.Pipelines;

  public class RegisterWebApiRoutes
  {
    public void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute(
        name: "Feature.Brochure.Api",
        url: "api/Brochure/{action}",
        defaults: new { controller = "Brochure" });
    }

  }
}