namespace Sitecore.Feature.Newsletter.Repositories
{
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Mvc.Presentation;

  internal interface ISectionOptionsRepository
  {
    ISectionOptions Get(RenderingParameters parameters);
  }
}