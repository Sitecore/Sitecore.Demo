using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.Brochure.Tests
{
  using FluentAssertions;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.FakeDb;
  using Sitecore.Feature.Brochure.Models;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Feature.Brochure.Services;
  using Sitecore.Foundation.Print.Services;
  using Sitecore.Foundation.Testing.Attributes;
  using Xunit;

  public class GenerateBrochureServiceTests
  {
    [AutoDbData]
    [Theory]
    public void GenerateBrochure_PrintProjectNotSet_ReturnStaticDownload(Db database, GenerateFileService generateFileService, Item brochureItem, IEnumerable<ID> items)
    {
      //TODO
    }
  }
}
