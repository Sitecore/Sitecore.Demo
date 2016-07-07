namespace Sitecore.Feature.Brochure.Tests
{
  using FluentAssertions;
  using Sitecore.Feature.Brochure.Models;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Foundation.Testing.Attributes;
  using Xunit;

  public class BrochureItemsRepositoryTests
  {
    [Theory, AutoDbData]
    public void Get_ReturnBrochureItems(IBrochureItems brochureItems)
    {
      var brochureRepository = new BrochureItemsRepository(brochureItems);
      var contextItems = brochureRepository.Get();
      contextItems.ShouldBeEquivalentTo(brochureItems);
    }
  }
}