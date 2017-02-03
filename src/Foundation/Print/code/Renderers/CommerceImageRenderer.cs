using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.PrintStudio.PublishingEngine;
using Sitecore.PrintStudio.PublishingEngine.Rendering;

namespace Sitecore.Foundation.Print.Renderers
{
    public class CommerceImageRenderer : InDesignItemRendererBase
    {
    

        public string position { get; set; }

        protected override void RenderContent(PrintContext printContext, XElement output)
        {
            XElement xElement = RenderItemHelper.CreateXElement("Image", base.RenderingItem, printContext.Settings.IsClient, null);
            string text = string.Empty;
            string value = base.RenderingItem["MediaLibrary Reference"];
            bool flag = string.IsNullOrEmpty(value);
            ID iD;
            if (!flag && ID.TryParse(value, out iD) && iD != ID.Null)
            {
                MediaItem mediaItem = printContext.Database.GetItem(iD);
                text = ImageRendering.CreateImageOnServer(printContext.Settings, mediaItem);
            }
            else
            {
                string text2 = base.RenderingItem.Parent["Item Field"];
                flag &= string.IsNullOrEmpty(text2);
                Item dataItem = this.GetDataItem(printContext);
                if (dataItem != null && !string.IsNullOrEmpty(text2))
                {
                    Field field = dataItem.Fields[text2];
                    if (field != null)
                    {
                        if (field.Type == "QR Code Image")
                        {
                            text = ImageRendering.CreateQrOnServer(printContext.Settings, base.RenderingItem, field.Value);
                        }
                        else if (field.Type == "Image")
                        {
                            MediaItem mediaItem2 = printContext.Database.GetItem(field.Value);
                            text = ImageRendering.CreateImageOnServer(printContext.Settings, mediaItem2);
                        }
                        else if (field.Type == "Treelist")
                        {

                            string[] images;
                            images = field.Value.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                            int intPosition;

                            if (position != null)
                            {
                               // intPosition = Convert.ToInt32(position);
                                intPosition = System.Convert.ToInt32(position);

                            }
                            else
                            {
                                intPosition = 0;
                            }

                            MediaItem mediaItem3 = printContext.Database.GetItem(images[intPosition]);
                            text = ImageRendering.CreateImageOnServer(printContext.Settings, mediaItem3);
                        }
                        else
                        { }
                    }
                }
            }
            if (string.IsNullOrEmpty(text) && flag)
            {
                xElement.SetAttributeValue("LowResSrc", base.RenderingItem["LowResSrc"]);
                xElement.SetAttributeValue("HighResSrc", base.RenderingItem["HighResSrc"]);
            }
            else
            {
                text = printContext.Settings.FormatResourceLink(text);
                xElement.SetAttributeValue("LowResSrc", text);
                xElement.SetAttributeValue("HighResSrc", text);
            }
            output.Add(xElement);
            this.RenderChildren(printContext, xElement);
        }
    }
}