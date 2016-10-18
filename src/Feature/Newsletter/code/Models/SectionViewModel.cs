namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data.Items;

  class SectionViewModel : ISectionViewModel
  {
    public Item ContentItem { get; set; }
    public ISectionOptions SectionOptions { get; set; }
    public INewsletterOptions NewsletterOptions { get; set;  }
  }
}