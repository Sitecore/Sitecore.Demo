namespace Sitecore.Feature.Brochure.Services
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Brochure.Models;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Foundation.Print.Services;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Resources.Media;

  public class GenerateBrochureService
  {
    public GenerateFileService GenerateFileService { get; set; }

    public GenerateBrochureService() : this(new GenerateFileService())
    {
      
    }

    public GenerateBrochureService([NotNull] GenerateFileService generateFileService)
    {
      if (generateFileService == null)
        throw new ArgumentNullException(nameof(generateFileService));
      GenerateFileService = generateFileService;
    }

    public Brochure GenerateBrochure([NotNull] Item brochureItem, [NotNull] IEnumerable<ID> items)
    {
      if (brochureItem == null)
        throw new ArgumentNullException(nameof(brochureItem));
      if (items == null)
        throw new ArgumentNullException(nameof(items));

      var fileName = GenerateValidFileName(brochureItem[Templates.Brochure.Fields.Title]) + $"_{DateTime.Now.Ticks}";

      var brochure = GetBrochureFromPrintStudio(brochureItem, fileName, items);
      return brochure ?? GetBrochureFromMediaLibrary(brochureItem, fileName);
    }

    private Brochure GetBrochureFromMediaLibrary(Item brochureItem, string fileName)
    {
      var mediaItem = ((FileField)brochureItem.Fields[Templates.Brochure.Fields.StaticDownload]).MediaItem;
      if (mediaItem == null)
        return null;
      var media = MediaManager.GetMedia(mediaItem);
      return new Brochure()
             {
               Content = media.GetStream().Stream,
               MimeType = media.MimeType,
               Filename = fileName + "." + media.Extension
             };
    }

    private Brochure GetBrochureFromPrintStudio([NotNull] Item brochureItem, [NotNull] string fileName, IEnumerable<ID> items)
    {
      if (!GenerateFileService.Enabled)
        return null;
      if (brochureItem == null)
        throw new ArgumentNullException(nameof(brochureItem));
      if (fileName == null)
        throw new ArgumentNullException(nameof(fileName));
      var projectItem = ((ReferenceField)brochureItem.Fields[Templates.Brochure.Fields.PrintStudioProject]).TargetItem;
      if (projectItem == null)
        return null;
      var fileInfo = GenerateFileService.GenerateFile(projectItem, items, fileName);
      if (fileInfo == null)
        return null;
      return new Brochure()
             {
               Content = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read),
               MimeType = "application/pdf",
               Filename = fileName + ".pdf"
             };
    }

    private string GenerateValidFileName(string fileName)
    {
      foreach (var c in System.IO.Path.GetInvalidFileNameChars())
      {
        fileName = fileName.Replace(c, '_');
      }
      return fileName;
    }
  }
}