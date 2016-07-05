namespace Sitecore.Feature.Favorites.Controllers
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Net;
  using System.Text;
  using System.Web.Mvc;
  using Sitecore.Configuration;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Favorites.Repositories;
  using Sitecore.Feature.Favorites.Services;
  using Sitecore.Foundation.Alerts.Extensions;
  using Sitecore.Foundation.Alerts.Models;
  using Sitecore.Foundation.Dictionary.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Attributes;
  using Sitecore.Mvc.Presentation;
  using Sitecore.PrintStudio.PublishingEngine;
  using Sitecore.PrintStudio.PublishingEngine.Helpers;
  //Added for PXM

  public class FavoritesController : Controller
  {
    private readonly IFavoritesRepository favoritesRepository;

    public FavoritesController() : this(new FavoritesRepository())
    {
    }

    public FavoritesController(IFavoritesRepository favoritesRepository)
    {
      this.favoritesRepository = favoritesRepository;
    }

    public ActionResult FavoritesMenu()
    {
      return View(favoritesRepository.Get());
    }


    public ActionResult Print()
    {
      var file = new GenerateFavoritesFileService().GenerateFavoritesFile();
      if (file == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Favorites/Print/File Generation Failed", "The personalised file could not be generated. Please try again.")));

      Response.ContentType = "application/pdf";
      Response.AppendHeader("content-disposition", $"attachment; filename={file.Name}");
      Response.AppendHeader("Content-Length", file.Length.ToString());
      Response.TransmitFile(file.FullName);
      Response.Flush();
      Response.End();

      return this.InfoMessage(InfoMessage.Info(DictionaryPhraseRepository.Current.Get("/Favorites/Print/File Was Generated", "Your personalised file was generated.")));
    }


    [SkipAnalyticsTracking]
    public ActionResult RemovePage(string ItemID)
    {
      var item = GetItem(ItemID);
      if (item == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var favorites = favoritesRepository.Get();
      if (!favorites.Remove(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("_Favorites", favorites);
    }

    private static Item GetItem(string ItemID)
    {
      if (ItemID == null || !ID.IsID(ItemID))
        return null;
      return Context.Database.GetItem(ItemID);
    }

    [SkipAnalyticsTracking]
    public ActionResult AddPage(string ItemID)
    {
      var item = GetItem(ItemID);
      if (item == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

      var favorites = favoritesRepository.Get();
      if (!favorites.Add(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("_Favorites", favorites);
    }
  }
}