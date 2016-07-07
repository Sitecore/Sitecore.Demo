﻿namespace Sitecore.Foundation.Print.Services
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;

  public class GenerateFileService : IGenerateFileService
  {
    public FileInfo GenerateFile(string projectPath, IEnumerable<ID> items, string fileName)
    {
      var projectItem = Context.Database.GetItem(projectPath);
      if (projectItem == null)
        return null;

      Logger.Info("File name at creation point:" + fileName + Environment.NewLine);
      var printOptions = new PrintOptions {
                           PrintExportType = PrintExportType.Pdf,
                           ResultFileName = fileName,
                           UseHighRes = false
                         };

      var itemsIDs = string.Join("|", items);
      printOptions.Parameters.Add("items", itemsIDs);

      var printManager = new PrintManager(Context.Database, Context.Language);
      var result = printManager.Print(projectItem.ID.ToString(), printOptions);
      if (!File.Exists(result))
      {
        throw new InvalidOperationException($"File generation failed, result: {result}");
      }

      return string.IsNullOrEmpty(result) ? null : new FileInfo(result);
    }
  }
}