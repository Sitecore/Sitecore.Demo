using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Favorites.Repositories
{
  using Sitecore.Data.Items;
  using Sitecore.Feature.Favorites.Models;

  public interface IFavoritesRepository
  {
    [NotNull]
    IFavorites Get();
  }
}