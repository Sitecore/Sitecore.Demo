namespace Sitecore.Feature.Newsletter.Repositories
{
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;

  public interface INewsletterOptionsRepository
  {
    INewsletterOptions Get(Item contextItem);
  }
}