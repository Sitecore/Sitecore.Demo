namespace Sitecore.Feature.Newsletter.Repositories
{
  using System;
  using System.Linq;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Feature.Newsletter.Services;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

  public class NewsletterOptionsRepository : INewsletterOptionsRepository
  {
    private readonly IFindNewsletterRootService findNewsletterRootService;
    private const int DefaultMaxWidth = 800;

    public NewsletterOptionsRepository() : this(new FindNewsletterRootService())
    {
    }

    public NewsletterOptionsRepository(IFindNewsletterRootService findNewsletterRootService)
    {
      this.findNewsletterRootService = findNewsletterRootService;
    }

    public INewsletterOptions Get([NotNull] Item contextItem)
    {
      if (contextItem == null)
        throw new ArgumentNullException(nameof(contextItem));

      var rootItem = findNewsletterRootService.FindNewsletterRoot(contextItem);
      var optionsItem = rootItem.Children.FirstOrDefault(c => c.IsDerived(Templates.NewsletterOptions.ID));
      if (optionsItem == null)
        throw new ArgumentException($"Cannot find NewsletterOptions below '{rootItem.Paths.FullPath}'");

      int maxWidth;
      if (!int.TryParse(optionsItem[Templates.NewsletterOptions.Fields.MaxWidth], out maxWidth))
        maxWidth = DefaultMaxWidth;

      return new NewsletterOptions
             {
               ContentFontSize = optionsItem[Templates.NewsletterOptions.Fields.ContentFontSize],
               FontFamily = optionsItem[Templates.NewsletterOptions.Fields.FontFamily],
               HeadingFontSize = optionsItem[Templates.NewsletterOptions.Fields.HeadingFontSize],
               MaxWidth = maxWidth,
               BeforeBodyHtml = optionsItem[Templates.NewsletterOptions.Fields.BeforeBodyHtml],
               AfterBodyHtml = optionsItem[Templates.NewsletterOptions.Fields.AfterBodyHtml]
            };
    }
  }
}