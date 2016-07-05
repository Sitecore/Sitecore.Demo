using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.Favorites.Tests
{
  using System.Web;
  using FluentAssertions;
  using NSubstitute;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.FakeDb;
  using Sitecore.Feature.Favorites.Models;
  using Sitecore.Feature.Favorites.Repositories;
  using Sitecore.Foundation.Testing.Attributes;
  using Xunit;

  public class SessionFavoritesTests
  {
    [Theory, AutoDbData]
    public void SessionFavorites_EmptySession_ItemsNotNullAndEmpty(HttpContext context)
    {
      var favorites = new SessionFavorites(context);
      favorites.Items.Should().NotBeNull();
      favorites.Items.Should().BeEmpty();
    }

    [Theory, AutoDbData]
    public void SessionFavorites_InitialisedSession_ItemsReturnsListOfFavorites(HttpContext context, List<Favorite> favoriteList)
    {
      context.Session.Add(SessionFavorites.SessionKey, favoriteList);
      var favorites = new SessionFavorites(context);
      
      favorites.Items.ShouldBeEquivalentTo(favoriteList);
    }

    [Theory, AutoDbData]
    public void Add_ItemAlreadyExists_ReturnsFalse(Db database, HttpContext context, List<Favorite> favoriteList)
    {
      database.Add(new DbItem("existing item", favoriteList[0].ItemID));
      var item = database.GetItem(favoriteList[0].ItemID);

      context.Session.Add(SessionFavorites.SessionKey, favoriteList);
      var favorites = new SessionFavorites(context);
      favorites.Add(item).Should().BeFalse();
    }

    [Theory, AutoDbData]
    public void Add_ItemDoesNotExist_ReturnsTrueAndItemsContainItem(Db database, HttpContext context, List<Favorite> favoriteList)
    {
      var itemID = ID.NewID;
      database.Add(new DbItem("existing item", itemID));
      var item = database.GetItem(itemID);

      context.Session.Add(SessionFavorites.SessionKey, favoriteList);
      var favorites = new SessionFavorites(context);
      favorites.Add(item).Should().BeTrue();
      favorites.Items.Should().Contain(f => f.ItemID == itemID);
    }

    [Theory, AutoDbData]
    public void Remove_ItemNotInItems_ReturnsFalse(Db database, HttpContext context, List<Favorite> favoriteList)
    {
      var itemID = ID.NewID;
      database.Add(new DbItem("new item", itemID));
      var item = database.GetItem(itemID);

      context.Session.Add(SessionFavorites.SessionKey, favoriteList);
      var favorites = new SessionFavorites(context);
      favorites.Remove(item).Should().BeFalse();
    }

    [Theory, AutoDbData]
    public void Remove_ItemInItems_ReturnsTrueAndItemsNotContainItem(Db database, HttpContext context, List<Favorite> favoriteList)
    {
      var itemID = favoriteList[0].ItemID;
      database.Add(new DbItem("existing item", itemID));
      var item = database.GetItem(itemID);

      context.Session.Add(SessionFavorites.SessionKey, favoriteList);
      var favorites = new SessionFavorites(context);
      favorites.Remove(item).Should().BeTrue();
      favorites.Items.Should().NotContain(f => f.ItemID == itemID);
    }
    [Theory, AutoDbData]
    public void Remove_ItemIsNull_ThrowsException(HttpContext context)
    {
      var favorites = new SessionFavorites(context);
      Assert.Throws<ArgumentNullException>(() => favorites.Remove(null));
    }
    [Theory, AutoDbData]
    public void Add_ItemIsNull_ThrowsException(HttpContext context)
    {
      var favorites = new SessionFavorites(context);
      Assert.Throws<ArgumentNullException>(() => favorites.Add(null));
    }
  }
}
