namespace Sitecore.Feature.Brochure.Models
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;

  public interface IBrochureItems
  {
    [NotNull]
    IEnumerable<BrochureItem> Items { get; }
    bool Remove(Item item);
    bool Add(Item item);
  }
}