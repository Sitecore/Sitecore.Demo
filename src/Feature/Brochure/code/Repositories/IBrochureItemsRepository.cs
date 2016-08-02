namespace Sitecore.Feature.Brochure.Repositories
{
  using Sitecore.Feature.Brochure.Models;

  public interface IBrochureItemsRepository
  {
    [NotNull]
    IBrochureItems Get();
  }
}