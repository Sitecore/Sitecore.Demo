namespace Sitecore.Feature.Newsletter.Services
{
  using Sitecore.Data.Items;

  public interface IFindNewsletterRootService
  {
    [NotNull]
    Item FindNewsletterRoot([NotNull] Item contextItem);
  }
}