using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sitecore.PrintStudio.PublishingEngine;
using Sitecore.PrintStudio.PublishingEngine.Rendering;
using Sitecore.PrintStudio.PublishingEngine.Text;
using Sitecore.Data.Fields;
using Sitecore.PrintStudio.PublishingEngine.Helpers;

namespace Sitecore.Feature.Favorites.PXMRenderers
{
  public class PXMParagraphStyle : XmlElementRenderer
  {
    /// <summary>
    /// Renders the content.
    /// </summary>
    /// <param name="printContext">The print context.</param>
    /// <param name="output">The output.</param>
    protected override void RenderContent(PrintContext printContext, XElement output)
    {
      // Create a temp node to serve as a container
      var temp = new XElement("temp");

      // Call the base to generate the element xml
      base.RenderContent(printContext, temp);

      // Select the generated paragraph style element
      var paragraph = temp.Element(this.Tag);
      if (paragraph != null)
      {
        // Get the data item assigned to the snippet
        var dataItem = this.GetDataItem(printContext);
        if (dataItem != null && !string.IsNullOrEmpty(this.RenderingItem["Item Field"]))
        {
          // Fetch the value for the field point in the ParagraphStyle element and add it as a CDATA
          Field field = dataItem.Fields[this.RenderingItem["Item Field"]];
          ParseContext context = new ParseContext(printContext.Database, printContext.Settings)
          {
            ParseDefinitions = RichTextParser.GetParseDefinitionCollection(base.RenderingItem)
          };
          string content = RichTextParser.ConvertToXml(field.Value, context, printContext.Language);
          XElement xElement = new XElement("temp");
          xElement.AddFragment(content);
          var result = xElement.Elements();
          paragraph.Add(result);
        }

        output.Add(paragraph);
      }
    }
  }
}
