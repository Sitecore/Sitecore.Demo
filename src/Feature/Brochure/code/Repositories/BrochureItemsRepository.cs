namespace Sitecore.Feature.Brochure.Repositories
{
  using Sitecore.Feature.Brochure.Models;

  public class BrochureItemsRepository : IBrochureItemsRepository
  {
    private readonly IBrochureItems contextBrochureItems;

    public BrochureItemsRepository() : this(new SessionBrochureItems())
    {
      
    }

    public BrochureItemsRepository(IBrochureItems contextBrochureItems)
    {
      this.contextBrochureItems = contextBrochureItems;
    }

    public IBrochureItems Get()
    {
      return contextBrochureItems;
    }
  }
}