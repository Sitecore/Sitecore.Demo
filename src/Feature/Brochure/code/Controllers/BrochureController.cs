namespace Sitecore.Feature.Brochure.Controllers
{
  using System.Net;
  using System.Web.Mvc;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Feature.Brochure.Services;
  using Sitecore.Foundation.Alerts.Extensions;
  using Sitecore.Foundation.Alerts.Models;
  using Sitecore.Foundation.Dictionary.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Attributes;

  public class BrochureController : Controller
  {
    private readonly IBrochureItemsRepository brochureItemsRepository;

    public BrochureController() : this(new BrochureItemsRepository())
    {
    }

    public BrochureController(IBrochureItemsRepository brochureItemsRepository)
    {
      this.brochureItemsRepository = brochureItemsRepository;
    }

    public ActionResult BrochureMenu()
    {
      return View(brochureItemsRepository.Get());
    }

    public ActionResult Print()
    {
      var file = new GenerateBrochureFileService().GenerateBrochureFile();
      if (file == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Brochure/Print/File Generation Failed", "The personalised file could not be generated. Please try again.")));

      Response.ContentType = "application/pdf";
      Response.AppendHeader("content-disposition", $"attachment; filename={file.Name}");
      Response.AppendHeader("Content-Length", file.Length.ToString());
      Response.TransmitFile(file.FullName);
      Response.Flush();
      Response.End();

      return this.InfoMessage(InfoMessage.Info(DictionaryPhraseRepository.Current.Get("/Brochure/Print/File Was Generated", "Your personalised file was generated.")));
    }


    [SkipAnalyticsTracking]
    public ActionResult RemovePage(string ItemID)
    {
      var item = GetItem(ItemID);
      if (item == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      var brochureItems = brochureItemsRepository.Get();
      if (!brochureItems.Remove(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("_BrochureItems", brochureItems);
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

      var brochureItems = brochureItemsRepository.Get();
      if (!brochureItems.Add(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View("_BrochureItems", brochureItems);
    }
  }
}