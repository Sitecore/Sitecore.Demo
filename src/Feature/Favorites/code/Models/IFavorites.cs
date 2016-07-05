using System.Collections.Generic;

namespace Sitecore.Feature.Favorites.Models
{
  using Sitecore.Data.Items;

  public interface IFavorites
  {
    [NotNull]
    IEnumerable<Favorite> Items { get; }
    bool Remove(Item item);
    bool Add(Item item);
  }
}