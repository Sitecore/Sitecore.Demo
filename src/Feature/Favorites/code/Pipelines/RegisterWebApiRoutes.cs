using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Favorites.Pipelines
{
  using System.Web.Mvc;
  using System.Web.Routing;
  using Sitecore.Pipelines;

  public class RegisterWebApiRoutes
  {
    public void Process(PipelineArgs args)
    {
      RouteTable.Routes.MapRoute(
        name: "Feature.Favorites.Api",
        url: "api/favorites/{action}",
        defaults: new { controller = "Favorites" });
    }

  }
}