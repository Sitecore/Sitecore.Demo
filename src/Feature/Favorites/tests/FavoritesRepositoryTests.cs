using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.Favorites.Tests
{
  using FluentAssertions;
  using Sitecore.Feature.Favorites.Models;
  using Sitecore.Feature.Favorites.Repositories;
  using Sitecore.Foundation.Testing.Attributes;
  using Xunit;

  public class FavoritesRepositoryTests
  {
    [Theory, AutoDbData]
    public void GetFromContext_ReturnContextFavorites(IFavorites favorites)
    {
      var favoritesRepository = new FavoritesRepository(favorites);
      var contextFavorites = favoritesRepository.Get();
      contextFavorites.ShouldBeEquivalentTo(favorites);
    }
  }
}
