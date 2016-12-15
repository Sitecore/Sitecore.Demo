
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDynamicContentRenderer.cs" company="Sitecore Corporation">
//   Copyright (C) 2012 by Sitecore Corporation
// </copyright>
// <summary>
//   Renders dynamic content element markup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Foundation.Print.Renderers
{
  using System;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;
  using PrintStudio.PublishingEngine.Helpers;

  /// <summary>
  /// Defines the XML dynamic content renderer class.
  /// </summary>
  public class XmlDynamicContentRenderer : XmlContentRenderer
  {
    /// <summary>
    /// Gets the data key.
    /// </summary>
    protected string DataKey
    {
      get
      {
        return this.RenderingItem["Data Key"];
      }
    }

    /// <summary>
    /// Gets the name of the field.
    /// </summary>
    /// <returns>
    /// The field name
    /// </returns>
    protected override string GetFieldName()
    {
      return this.RenderingItem["Item Field"];
    }

    /// <summary>
    /// Preliminary render action invoked before RenderContent <see cref="InDesignItemRendererBase.RenderContent"/>.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    protected override void BeginRender(PrintContext printContext)
    {
      string dataSource = string.Empty;
      var dataItem = this.GetDataItem(printContext);

      if (dataItem != null)
      {
        dataSource = dataItem.ID.ToString();
      //  Logger.Info("Got Data Item:" + dataSource);

      }

      if (!string.IsNullOrEmpty(this.RenderingItem["Item Reference"]))
      {
        dataSource = this.RenderingItem["Item Reference"];
        
    }

      try
      {
        if (!string.IsNullOrEmpty(this.DataKey))
        {
          string dataItemId = printContext.Settings.Parameters[this.DataKey].ToString();
          if (!string.IsNullOrEmpty(dataItemId))
          {
            dataSource = dataItemId;
          }
        }

        if (!string.IsNullOrEmpty(dataSource))
        {
          this.ContentItem = printContext.Database.GetItem(dataSource);

          var xpath = this.RenderingItem["Item Selector"];
          if (!string.IsNullOrEmpty(xpath))
          {
            Item selectorDataItem = this.ContentItem.Axes.SelectSingleItem(xpath);
            if (selectorDataItem != null)
            {
              this.ContentItem = selectorDataItem;
            }
          }
        }
      }
      catch (Exception exc)
      {
        Log.Error(exc.Message, this);
      }
    }
  }
}
