namespace Sitecore.Feature.Newsletter.Models
{
  public interface INewsletterOptions
  {
    string FontFamily { get; }
    string HeadingFontSize { get; }
    string ContentFontSize { get; }
    int MaxWidth { get; }
    string BeforeBodyHtml { get; }
    string AfterBodyHtml { get; }
  }
}