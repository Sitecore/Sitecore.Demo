namespace Sitecore.Feature.Favorites.Repositories
{
  using System;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Favorites.Models;

  public class FavoritesRepository : IFavoritesRepository
  {
    private readonly IFavorites contextFavorites;

    public FavoritesRepository() : this(new SessionFavorites())
    {
      
    }

    public FavoritesRepository(IFavorites contextFavorites)
    {
      this.contextFavorites = contextFavorites;
    }

    public IFavorites Get()
    {
      return contextFavorites;
    }
  }
}