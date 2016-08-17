namespace Sitecore.Feature.Newsletter.Models
{
  internal class NewsletterOptions : INewsletterOptions
  {
    public string FontFamily { get; set; }
    public string HeadingFontSize { get; set; }
    public string ContentFontSize { get; set; }
    public int MaxWidth { get; set; }
    public string BeforeBodyHtml { get; set; }
    public string AfterBodyHtml { get; set; }
    public string HeaderBackgroundColor { get; set; }
    public string HeaderFontColor { get; set; }
    public string FooterBackgroundColor { get; set; }
    public string FooterFontColor { get; set;  }
  }
}