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
  using Sitecore.Foundation.Print.Services;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;

  public class GenerateFavoritesFileService
  {
    public IFavoritesRepository FavoritesRepository { get; }
    public GenerateFileService GenerateFileService { get; set; }

    public GenerateFavoritesFileService() : this(new FavoritesRepository(), new GenerateFileService())
    {
      
    }

    private GenerateFavoritesFileService(IFavoritesRepository favoritesRepository, GenerateFileService generateFileService)
    {
      FavoritesRepository = favoritesRepository;
      GenerateFileService = generateFileService;
    }

    public FileInfo GenerateFavoritesFile()
    {
      var pxmProjectPath = "/sitecore/Print Studio/Print Studio Projects/Legal/PXM on Demand";
      var itemIDs = FavoritesRepository.Get().Items.Select(f => f.ItemID);
      var fileName = $"CR_Practise_Areas_{DateTime.Now.Ticks}";

      return GenerateFileService.GenerateFile(pxmProjectPath, itemIDs, fileName);
    }
  }
}