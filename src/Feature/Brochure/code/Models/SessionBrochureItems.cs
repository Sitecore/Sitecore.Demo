namespace Sitecore.Feature.Brochure.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Web;
  using Sitecore.Data.Items;
  using Sitecore.Links;

  public class SessionBrochureItems : IBrochureItems
  {
    private readonly HttpContext context;
    public const string SessionKey = "BrochureItems";

    public SessionBrochureItems() : this(HttpContext.Current)
    {
    }

    public SessionBrochureItems(HttpContext context)
    {
      this.context = context;
    }

    public IEnumerable<BrochureItem> Items => SessionItems;

    private List<BrochureItem> SessionItems
    {
      get
      {
        lock (context.Session)
        {
          var items = context.Session[SessionKey] as List<BrochureItem>;
          if (items != null)
            return items;
          items = new List<BrochureItem>();
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
        var brochureItem = SessionItems.FirstOrDefault(f => f.ItemID == item.ID);
        if (brochureItem == null)
          return false;
        SessionItems.Remove(brochureItem);
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

        SessionItems.Add(new BrochureItem
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