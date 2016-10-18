namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data.Items;

  public interface IListSectionViewModel
  {
    Item ParentItem { get; }
    Item[] Items { get; }
    ISectionOptions SectionOptions { get; }
    INewsletterOptions NewsletterOptions { get; }
  }
}