namespace Sitecore.Feature.Newsletter.Repositories
{
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Mvc.Presentation;

  internal class SectionOptionsRepository : ISectionOptionsRepository
  {
    public ISectionOptions Get(RenderingParameters parameters)
    {
      var options = new SectionOptions()
                    {
                      BackgroundColor = GetParameter(parameters, Templates.NewsletterSectionParameters.RenderingParameters.BackgroundColor, "#fff"),
                      ContentFontColor = GetParameter(parameters, Templates.NewsletterSectionParameters.RenderingParameters.ContentFontColor, "#000"),
                      HeadingFontColor = GetParameter(parameters, Templates.NewsletterSectionParameters.RenderingParameters.HeadingFontColor, "#000"),
                      LinkColor = GetParameter(parameters, Templates.NewsletterSectionParameters.RenderingParameters.LinkColor, "#000")
      };
      return options;
    }
    private static string GetParameter(RenderingParameters parameters, string name, string defaultValue = "")
    {
      return !parameters.Contains(name) ? defaultValue : parameters[name];
    }
  }
}