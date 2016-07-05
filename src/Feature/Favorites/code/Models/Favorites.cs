namespace Sitecore.Feature.Favorites.Models
{
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Links;
  using Sitecore.Web.Authentication;

  public class SessionFavorites : IFavorites
  {
    private readonly HttpContext context;
    public const string SessionKey = "Favorites";

    public SessionFavorites() : this(HttpContext.Current)
    {
    }

    public SessionFavorites(HttpContext context)
    {
      this.context = context;
    }

    public IEnumerable<Favorite> Items => SessionItems;

    private List<Favorite> SessionItems
    {
      get
      {
        lock (context.Session)
        {
          var items = context.Session[SessionKey] as List<Favorite>;
          if (items != null)
            return items;
          items = new List<Favorite>();
          context.Session.Add(SessionKey, items);
          return items;
        }
      }
    }

    public bool Remove([NotNull] Item item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      lock (SessionItems)
      {
        var favorite = SessionItems.FirstOrDefault(f => f.ItemID == item.ID);
        if (favorite == null)
          return false;
        SessionItems.Remove(favorite);
        return true;
      }
    }

    public bool Add([NotNull] Item item)
    {
      if (item == null)
        throw new ArgumentNullException(nameof(item));

      lock (SessionItems)
      {
        if (SessionItems.Any(f => f.ItemID == item.ID))
          return false;

        SessionItems.Add(new Favorite
                         {
                           ItemID = item.ID,
                           ItemUrl = LinkManager.GetItemUrl(item),
                           Title = item.Name
                         });
        return true;
      }
    }
  }
}