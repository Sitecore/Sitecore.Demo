
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlContentRenderer.cs" company="Sitecore Corporation">
//   Copyright (C) 2012 by Sitecore Corporation
// </copyright>
// <summary>
//   Renders paragraph style element markup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Foundation.Print.Renderers
{
  using System;
  using System.Linq;
  using System.Xml;
  using System.Xml.Linq;
  using Sitecore;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;
  using PrintStudio.PublishingEngine.Helpers;

  /// <summary>
  /// Renders paragraph style element markup.
  /// </summary>
  public class XmlContentRenderer : InDesignItemRendererBase
  {
    /// <summary>
    /// Static Text Field Name
    /// </summary>
    private const string StaticTextFieldName = "Content";

    /// <summary>
    /// Content item
    /// </summary>
    private Item contentItem;

    /// <summary>
    /// Gets or sets the content field.
    /// </summary>
    /// <value>
    /// The content field.
    /// </value>
    private string contentFieldName;

    /// <summary>
    /// Gets or sets the name of the content field.
    /// </summary>
    /// <value>
    /// The name of the content field.
    /// </value>
    public string ContentFieldName
    {
      get
      {
        if (string.IsNullOrEmpty(this.contentFieldName))
        {
          this.contentFieldName = this.GetFieldName();
        }

        return this.contentFieldName;
      }

      set
      {
        this.contentFieldName = value;
      }
    }

    /// <summary>
    /// Gets or sets the content item.
    /// </summary>
    /// <value>
    /// The internal data.
    /// </value>
    protected virtual Item ContentItem
    {
      get
      {
        return this.contentItem ?? (this.contentItem = this.RenderingItem);
      }

      set
      {
        this.contentItem = value;
      }
    }

    /// <summary>
    /// Gets the name of the field.
    /// </summary>
    /// <returns>The field name</returns>
    protected virtual string GetFieldName()
    {
      return StaticTextFieldName;
    }

    /// <summary>
    /// Renders the content.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    /// <param name="output">The output.</param>
    protected override void RenderContent(PrintContext printContext, [NotNull] XElement output)
    {
      string content = this.ParseContent(printContext);
      XElement tempContentNode;

     // Logger.Info(">>>>>Incoming Content:" + content);

      try
      {
        tempContentNode = XElement.Parse(string.Format("<TempContentRoot>{0}</TempContentRoot>", content));
      }
      catch (Exception exc)
      {
        Log.Error("Render content parse content value", exc, this);
        return;
      }

      if (!tempContentNode.HasElements)
      {
        var plainTextNodes = tempContentNode.Nodes().Where(t => t.NodeType == XmlNodeType.Text);
        foreach (var plainTextNode in plainTextNodes)
        {
          plainTextNode.ReplaceWith(new XCData(plainTextNode.ToString()));
        }

        output.Add(tempContentNode.Nodes());
        this.RenderChildren(printContext, output);
      //  Logger.Info("Output:" + output.ToString());
      }
      else
      {
        XElement currentNode = output;
        if (tempContentNode.Elements().Count() == 1)
        {
          currentNode = tempContentNode.Elements().First();
        }

        // first render children, then add the nodes, prevents from losing the children xml
        this.RenderChildren(printContext, currentNode);
        output.Add(tempContentNode.Nodes());
      }
    }

    /// <summary>
    /// Parses the content.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    /// <returns>
    /// The content.
    /// </returns>
    protected virtual string ParseContent(PrintContext printContext)
    {
      Assert.IsNotNull(this.ContentItem, "Content item is null");
      Assert.IsNotNullOrEmpty(this.ContentFieldName, "Missing content field");

      Field contentField = this.ContentItem.Fields[this.ContentFieldName];
      if (contentField == null)
      {
        return string.Empty;
      }

      CustomField field = FieldTypeManager.GetField(contentField);
      if (field == null)
      {
        return contentField.Value;
      }

      if (field is HtmlField)
      {
        //Item defaultFormatting = printContext.Settings.GetDefaultFormattingItem(printContext.Database);
        Item defaultFormatting = PrintStudio.PublishingEngine.Text.RichTextParser.GetDefaultFormattingItem(printContext.Database);

        if (defaultFormatting != null)
        {
          try
          {
           // XmlDataDocument tempDoc = new XmlDataDocument();
            //return PatternBuilder.TransformRichContent(field.Value, printContext.Database, tempDoc, defaultFormatting, "XHTML", "XML");
          }
          catch (Exception exc)
          {
            Log.Error(exc.Message, this);
          }
        }

        return null; //PatternBuilder.RichTextToTextParser(field.Value, true, false);
      }

      return field.Value;
    }
  }
}
