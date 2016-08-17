namespace Sitecore.Feature.Newsletter.Repositories
{
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;

  internal interface IFixedSectionOptionsRepository
  {
    IFixedSectionOptions Get(Item newsletterItem, ID fixedSectionTemplateID);
  }
}