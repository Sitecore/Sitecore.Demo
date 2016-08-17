namespace Sitecore.Feature.Newsletter.Repositories
{
  using System;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

  internal class FixedSectionOptionsRepository : IFixedSectionOptionsRepository
  {
    public IFixedSectionOptions Get([NotNull] Item newsletterItem, ID fixedSectionTemplateID)
    {
      if (newsletterItem == null)
        throw new ArgumentNullException(nameof(newsletterItem));
      var fixedSectionItem = newsletterItem.Children.FirstOrDefault(c => c.IsDerived(fixedSectionTemplateID));
      if (fixedSectionItem == null)
        return null;
      return new FixedSectionOptions()
             {
               BackgroundColor = fixedSectionItem[Templates.FixedSection.Fields.BackgroundColor],
               FontColor = fixedSectionItem[Templates.FixedSection.Fields.FontColor],
               LinkItems = fixedSectionItem.Children.Where(c => c.IsDerived(Templates.Link.ID)).ToArray()
             };
    }
  }
}