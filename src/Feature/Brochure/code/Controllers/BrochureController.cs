namespace Sitecore.Feature.Brochure.Controllers
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Web.Mvc;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Brochure.Models;
  using Sitecore.Feature.Brochure.Repositories;
  using Sitecore.Feature.Brochure.Services;
  using Sitecore.Foundation.Alerts.Extensions;
  using Sitecore.Foundation.Alerts.Models;
  using Sitecore.Foundation.Dictionary.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Attributes;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Mvc.Presentation;

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
      var brochureItem = RenderingContext.Current.Rendering.Item;
      if (brochureItem == null || !brochureItem.IsDerived(Templates.Brochure.ID))
        return new EmptyResult();
      var addToBrochureItem = RenderingContext.Current.ContextItem;

      var allowInBrochure = addToBrochureItem.IsDerived(Templates.AllowInBrochure.ID) && addToBrochureItem.Fields[Templates.AllowInBrochure.Fields.AllowInBrochure].IsChecked();

      var viewModel = new BrochureMenuViewModel()
                      {
                        Items = brochureItemsRepository.Get(),
                        AllowCurrentItemInBrochure = allowInBrochure,
                        BrochureItem = brochureItem,
                        AddToBrochureItem = addToBrochureItem
                      };

      return View(viewModel);
    }

    public ActionResult BrochureTeaser()
    {
      var brochureItem = RenderingContext.Current.Rendering.Item;
      if (brochureItem == null || !brochureItem.IsDerived(Templates.Brochure.ID))
        return new EmptyResult();
      return View(brochureItem);
    }

    public ActionResult Print(Guid brochure)
    {
      var brochureItem = Context.Database.GetItem(new ID(brochure));
      var items = GetBrochureItemIDs();
      if (brochureItem == null || items == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Brochure/Print/No Brochure Specified", "No brochure was specified.")));
      var generatedBrochure = new GenerateBrochureService().GenerateBrochure(brochureItem, items);
      if (generatedBrochure == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Brochure/Print/File Generation Failed", "The personalised file could not be generated. Please try again.")));
      return File(generatedBrochure.Content, generatedBrochure.MimeType, generatedBrochure.Filename);
    }

    private IEnumerable<ID> GetBrochureItemIDs()
    {
      var brochureItems = brochureItemsRepository.Get();
      return brochureItems.Items.Any() ? brochureItems.Items.Select(i => i.ItemID) : new []{RenderingContext.Current.ContextItem.ID};
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