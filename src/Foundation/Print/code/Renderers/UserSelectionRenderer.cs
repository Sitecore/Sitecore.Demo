namespace Sitecore.Foundation.Print.Renderers
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using System.Linq;
  using System.Text.RegularExpressions;
  using System.Web;
  using System.Xml.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Diagnostics;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;
  using Sitecore.Web;

  public class UserSelectionRenderer : XmlTextFrameRenderer
  {
    public string DataSources { get; set; }

    protected override void RenderContent(PrintContext printContext, XElement output)
    {
      var tempElement = new XElement("temp");
      base.RenderContent(printContext, tempElement);

      var textFrame = tempElement.Element("TextFrame");
      if (textFrame == null)
        return;

      var textParagraph = textFrame.Element("ParagraphStyle");
      if (textParagraph != null)
      {
        var items = GetUserSelectionItems(printContext);

        var textValue = textParagraph.Value;
        var fieldToReplace = GetFieldsToReplace(textValue);
        foreach (var field in fieldToReplace)
        {
          var userSelectionString = string.Join(Separator, items.Select(item => item[field]));
          textValue = textValue.Replace($"${field}", userSelectionString);
        }
        textParagraph.ReplaceNodes(new XCData(textValue));
      }

      output.Add(textFrame);
    }

    private string Separator
    {
      get
      {
        var configuredValue = ((NameValueListField)this.RenderingItem.Fields["Parameters"]).NameValues["FieldValueSeperator"];
        return string.IsNullOrEmpty(configuredValue) ? ", " : HttpUtility.UrlDecode(configuredValue);
      }
    }

    private IEnumerable<string> GetFieldsToReplace(string textToReplace)
    {
      var matches = Regex.Matches(textToReplace, @"\$(\w+)");
      foreach (Match match in matches)
      {
        yield return match.Groups[1].Value;
      }

    }

    private Item[] GetUserSelectionItems(PrintContext printContext)
    {
      var value = this.RenderingItem.Parent.Fields[Templates.P_Snippet.Fields.DataKey].Value;
      if (value == null)
        throw new ConfigurationErrorsException("Data Key field not set");
      var parameter = printContext.Settings.Parameters[value];
      if (parameter == null)
        throw new ConfigurationErrorsException($"Invalid parameter '{value}'");
      var items = GetSelectedItems(parameter.ToString(), printContext.Database);
      return items;
    }

    private Item[] GetSelectedItems(string userSelections, Database database)
    {
      var itemIDs = userSelections.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
      return itemIDs.Select(database.GetItem).Where(item => item != null).ToArray();
    }
  }
}