namespace Sitecore.Feature.Favorites.PXMRenderers
{
  using System;
  using System.Linq;
  using System.Xml.Linq;
  using Sitecore.Diagnostics;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;

  public class UserSelectionRenderer : XmlTextFrameRenderer
  {
    /// <summary>
    ///   Renders the content.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    /// <param name="output">The output.</param>
    public string userSelections { get; set; }

    public string DataSources { get; set; }
    private string userSelectionsString = "";


    protected override void RenderContent(PrintContext printContext, XElement output)
    {
      Logger.Info("Running Practise Areas Renderer....");
      try
      {
        userSelections = printContext.Settings.Parameters[RenderingItem.Parent.Fields["Data Key"].Value].ToString();
        userSelections = userSelections.TrimEnd('|'); //Clean up as something derpy is going on :(

        var items = StringUtil.Split(userSelections, '|', true);
        var itemsCount = items.Count();
        var itemCounter = 1;
        foreach (var item in items)
        {
          var dataItem = printContext.Database.GetItem(item);
          var itemTitle = dataItem.Fields["Title"].ToString();
          if (itemCounter < itemsCount)
          {
            userSelectionsString = userSelectionsString + itemTitle + " | ";
          }
          else
          {
            userSelectionsString = userSelectionsString + itemTitle;
          }
          itemCounter++;
        }

        var tempElement = new XElement("temp");
        base.RenderContent(printContext, tempElement);

        var textFrame = tempElement.Element("TextFrame");
        if (textFrame != null)
        {
          var textParagraph = textFrame.Element("ParagraphStyle");
          if (textParagraph != null)
          {
            var textValue = textParagraph.Value;
            textParagraph.ReplaceNodes(new XCData(textValue.Replace("$userSelections", userSelectionsString)));
          }

          output.Add(textFrame);
        }
      }
      catch (Exception exc)
      {
        Log.Error("Rendering the user selected Practise Area text.", exc, this);
      }
    }
  }
}