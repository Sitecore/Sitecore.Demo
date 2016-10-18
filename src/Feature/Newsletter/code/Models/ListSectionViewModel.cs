namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data.Items;

  internal class ListSectionViewModel : IListSectionViewModel
  {
    public Item ParentItem { get; set;  }
    public Item[] Items { get; set; }
    public ISectionOptions SectionOptions { get; set; }
    public INewsletterOptions NewsletterOptions { get; set; }
  }
}