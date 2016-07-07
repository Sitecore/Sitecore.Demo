namespace Sitecore.Foundation.Print.Renderers
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Linq;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;
  using Sitecore.PrintStudio.PublishingEngine.Rendering;
  using Sitecore.PrintStudio.PublishingEngine.Text;

  public class ParagraphStyleRenderer : XmlElementRenderer
  {
    protected override void RenderContent(PrintContext printContext, XElement output)
    {
      var paragraph = GetRenderedParagraph(printContext);
      if (paragraph == null)
        return;
      
      paragraph.Add(GetItemParagraphs(printContext));

      output.Add(paragraph);
    }

    private IEnumerable<XElement> GetItemParagraphs(PrintContext printContext)
    {
      var dataItem = GetDataItem(printContext);
      var dataItemField = RenderingItem[Templates.DataReference.Fields.ItemField];
      if (dataItem == null || string.IsNullOrEmpty(dataItemField))
        return Enumerable.Empty<XElement>();

      // Fetch the value for the field point in the ParagraphStyle element and add it as a CDATA
      var field = dataItem.Fields[dataItemField];
      var context = new ParseContext(printContext.Database, printContext.Settings)
                    {
                      ParseDefinitions = RichTextParser.GetParseDefinitionCollection(RenderingItem)
                    };
      var content = RichTextParser.ConvertToXml(field.Value, context, printContext.Language);
      var xElement = new XElement("temp");
      xElement.AddFragment(content);
      return xElement.Elements();
    }

    private XElement GetRenderedParagraph(PrintContext printContext)
    {
      var temp = new XElement("temp");
      base.RenderContent(printContext, temp);
      return temp.Element(Tag);
    }
  }
}