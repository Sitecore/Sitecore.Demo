namespace Sitecore.Foundation.Print.Services
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;
  using Configuration;
  public class GenerateFileService : IGenerateFileService
  {
    public FileInfo GenerateFile([NotNull] Item projectItem, [NotNull] IEnumerable<ID> items, [NotNull] string fileName)
    {
      if (projectItem == null)
        throw new ArgumentNullException(nameof(projectItem));
      if (items == null)
        throw new ArgumentNullException(nameof(items));
      if (fileName == null)
        throw new ArgumentNullException(nameof(fileName));

      Logger.Info("GenerateFileService File name at creation point:" + fileName + Environment.NewLine);
      var printOptions = new PrintOptions {
                           PrintExportType = PrintExportType.Pdf,
                           ResultFileName = fileName,
                           UseHighRes = false
                         };

      var itemsIDs = string.Join("|", items);
      printOptions.Parameters.Add("items", itemsIDs);
           

      //var printManager = new PrintManager(Context.Database, Context.Language);
      PrintManager printManager = new PrintManager(Context.Database, Context.Language);


      Logger.Info("We got a print manager: " + printManager.ToString());

      var result = printManager.Print(projectItem.ID.ToString(), printOptions);

      Logger.Info("We got a project item: " + projectItem.ID.ToString());

      Logger.Info("Result:" + result.ToString());

   if (!File.Exists(result))
      {
        throw new InvalidOperationException($"File generation failed, result: {result}");
      }

      return string.IsNullOrEmpty(result) ? null : new FileInfo(result);
    }
  }
}