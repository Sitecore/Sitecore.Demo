namespace Sitecore.Foundation.Print.Services
{
  using System.Collections.Generic;
  using System.IO;
  using Sitecore.Data;
  using Sitecore.Data.Items;

  public interface IGenerateFileService
  {
    FileInfo GenerateFile(string projectPath, IEnumerable<ID> items, string fileName);
  }
}