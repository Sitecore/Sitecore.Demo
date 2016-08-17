namespace Sitecore.Feature.Newsletter.Services
{
  using System;
  using Sitecore.Configuration;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

  public class FindNewsletterRootService : IFindNewsletterRootService
  {
    public Item FindNewsletterRoot(Item contextItem)
    {
      if (contextItem == null)
        throw new ArgumentNullException(nameof(contextItem));
      var newsletterRootItem = contextItem.GetAncestorOrSelfOfTemplate(NewsletterRootTemplate);
      if (newsletterRootItem == null)
        throw new ArgumentException($"Cannot find a newsletter root of type \'NewsletterRootTemplate\' above \'{contextItem.Paths.FullPath}\'", nameof(contextItem));
      return newsletterRootItem;
    }

    public ID NewsletterRootTemplate => ID.Parse(Settings.GetSetting("Feature.Newsletter.NewsletterRootTemplate"));
  }
}