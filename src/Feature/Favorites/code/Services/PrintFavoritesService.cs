using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Favorites.Services
{
  using System.IO;
  using System.Text;
  using Sitecore.Configuration;
  using Sitecore.Feature.Favorites.Repositories;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;

  public class GenerateFavoritesFileService
  {
    public IFavoritesRepository FavoritesRepository { get; }

    public GenerateFavoritesFileService() : this(new FavoritesRepository())
    {
      
    }

    private GenerateFavoritesFileService(IFavoritesRepository favoritesRepository)
    {
      FavoritesRepository = favoritesRepository;
    }

    public FileInfo GenerateFavoritesFile()
    {
      string pxmProjectPath = "/sitecore/Print Studio/Print Studio Projects/PXM on Demand";

      var projectItem = Context.Database.GetItem(pxmProjectPath);
      if (projectItem == null)
        return null;

      var fileName = $"CR_Practise_Areas_{DateTime.Now.Ticks}";
      Logger.Info("File Name at creation Point:" + fileName + Environment.NewLine);
      var printOptions = new PrintOptions
                         {
                           PrintExportType = PrintExportType.Pdf,
                           ResultFileName = fileName,
                           UseHighRes = false
                         };

      var favorites = string.Join("|", FavoritesRepository.Get().Items.Select(f => f.ItemID));
      printOptions.Parameters.Add("practiseAreas", favorites);

      var printManager = new PrintManager(Context.Database, Context.Language);
      var result = printManager.Print(projectItem.ID.ToString(), printOptions);

      return string.IsNullOrEmpty(result) ? null : new FileInfo(result);
    }
  }
}