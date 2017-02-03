using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Threading.Tasks;
using Sitecore.PrintStudio.PublishingEngine.Rendering;
using System.Xml.Linq;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.PrintStudio.PublishingEngine;
using Sitecore.Commerce;
using Sitecore.Commerce.Services.Prices;

namespace Sitecore.Foundation.Print.Renderers
{
    public class GetCommerceFieldRenderer : XmlTextFrameRenderer
    {
    

        protected override void RenderContent(PrintContext printContext, XElement output)
        {
            XElement baseXml = new XElement("base");
            base.RenderContent(printContext, baseXml);

            XElement textFrame = baseXml.Element("TextFrame");
            Item dataItem = GetDataItem(printContext);

            XElement xElement = RenderItemHelper.CreateXElement("TextFrame", base.RenderingItem, printContext.Settings.IsClient, dataItem);
            this.SetAttributes(xElement);

            output.Add(xElement);

            XAttribute xAttribute = output.Attribute("ParagraphStyle");
            string text = (RenderingItem["ParagraphStyle"].ToString() != null) ? RenderingItem["ParagraphStyle"].ToString() : "H1 Orange";

            string fieldtype = dataItem.Fields[this.ContentFieldName].Type;

            string input = dataItem.Fields[this.ContentFieldName].ToString();
            string outputtext = "";

            if (fieldtype == "Commerce Decimal Control")
            {
                outputtext = System.Convert.ToDecimal(input).ToString("c");
            }
            else if (fieldtype == "Commerce Read-Only Control")
            {
                outputtext = input;
            }
            else
            {
                // No transformation
                outputtext = input;
            }
            //var price = response.Prices.ContainsKey(ListPriceKey) ? response.Prices[ListPriceKey].Amount : decimal.Zero;

            //var price = this.pricingService.GetProductPrice("11");

            IEnumerable<XElement> result = this.FormatText(text, outputtext);

            xElement.Add(result);

            this.RenderChildren(printContext, xElement);
        }
    }
}