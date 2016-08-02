namespace Sitecore.Foundation.Print.Renderers
{
  using System;
  using System.Linq;
  using System.Xml.Linq;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;

  public class XMLRepeaterRenderer : InDesignItemRendererBase
  {
    public string DataSources { get; set; }
    public string Count { get; set; }
    public string ChildDataKeyName { get; set; }

    protected override void BeginRender(PrintContext printContext)
    {
      if (!string.IsNullOrEmpty(RenderingItem["Item Reference"]))
      {
        DataSource = RenderingItem["Item Reference"];
      }

      if (!string.IsNullOrEmpty(RenderingItem["Data Key"]) && printContext.Settings.Parameters.ContainsKey(RenderingItem["Data Key"]))
      {
        var data = printContext.Settings.Parameters[RenderingItem["Data Key"]].ToString();
        if (!string.IsNullOrEmpty(data))
        {
          var items = StringUtil.Split(data, '|', true);
          if (items.Count() > 1)
          {
            DataSources = data;
            return;
          }

          var contextItem = printContext.Database.GetItem(data);
          if (contextItem != null)
          {
            DataSource = contextItem.ID.ToString();
          }
        }
      }

      // Get the data item assigned to the repeater
      var dataItem = GetDataItem(printContext);
      if (dataItem != null)
      {
        // apply the selector to the data item
        if (!string.IsNullOrEmpty(RenderingItem["Item Selector"]))
        {
          var xpath = RenderingItem["Item Selector"];
          if (!string.IsNullOrEmpty(xpath))
          {
            var items = dataItem.Axes.SelectItems(xpath);
            if (items != null)
            {
              DataSources = string.Join("|", items.Select(t => t.ID.ToString()).ToArray());
            }
          }
        }
        else if (!string.IsNullOrEmpty(RenderingItem["Item Field"]))
        {
          // Get the number of times we need to repeat the child elements
          Count = dataItem[RenderingItem["Item Field"]];
        }
      }
    }

    protected override void RenderContent(PrintContext printContext, XElement output)
    {
      if (!string.IsNullOrEmpty(ChildDataKeyName))
      {
        printContext.Settings.Parameters[ChildDataKeyName] = DataSource;
      }

      if (!string.IsNullOrEmpty(DataSources))
      {
        foreach (var dataSource in DataSources.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries))
        {
          DataSource = dataSource;
          if (!string.IsNullOrEmpty(ChildDataKeyName))
          {
            printContext.Settings.Parameters[ChildDataKeyName] = dataSource;
          }

          RenderChildren(printContext, output);
        }

        return;
      }

      var dataItem = GetDataItem(printContext);
      if (dataItem == null && !printContext.Settings.IsClient)
      {
        return;
      }

      int count;
      if (!string.IsNullOrEmpty(Count) && int.TryParse(Count, out count) && count > 0)
      {
        for (var i = 0; i < count; i++)
        {
          // Render child elements
          RenderChildren(printContext, output);
        }

        return;
      }

      RenderChildren(printContext, output);
    }
  }
}