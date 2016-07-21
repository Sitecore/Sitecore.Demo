using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.PrintStudio.PublishingEngine.Rendering;
using Sitecore.Data.Items;
using Sitecore.PrintStudio.PublishingEngine;
using Sitecore;
using Sitecore.Data.Fields;

namespace Sitecore.Foundation.Print.Renderers
{
  public class XmlLookupTextframe : XmlElementRenderer
  {
    public string LookupField
    {
      get;
      set;
    }
    protected override Item GetDataItem(PrintContext printContext)
    {
      Item result = null;
      string dataSource = this.DataSource;
      if (dataSource.Length > 0)
      {
        if (MainUtil.IsFullPath(dataSource))
        {
          Item dataItem = printContext.Database.GetItem(dataSource);
          Field lookupfield = dataItem.Fields[this.LookupField]; // this is the contributors field
          String lookupfieldvalue = lookupfield.Value;
          Item lookupItem = printContext.Database.GetItem(lookupfieldvalue);
          result = lookupItem;
        }
        else
        {
          result = this.RenderingItem.Axes.GetItem(dataSource);
        }
      }
      return result;
    }
  }
}
