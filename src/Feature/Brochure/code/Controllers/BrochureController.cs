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
  using Sitecore.Reflection;

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


      var viewModel = new BrochureMenuViewModel
      {
                        Items = brochureItemsRepository.Get(),
                        AllowCurrentItemInBrochure = CheckAllowInBrochure(addToBrochureItem),
                        BrochureItem = brochureItem,
                        AddToBrochureItem = addToBrochureItem
                      };

      return View(viewModel);
    }

    private static bool CheckAllowInBrochure(Item item)
    {
      return item.IsDerived(Templates.AllowInBrochure.ID) && item.Fields[Templates.AllowInBrochure.Fields.AllowInBrochure].IsChecked();
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
    public ActionResult PrintPage(Guid brochure, Guid page)
    {
      var brochureItem = Context.Database.GetItem(new ID(brochure));

      var pageItemId = new ID(page);
      var item = GetItem(pageItemId.ToString());
      if (brochureItem == null || item == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Brochure/Print/No Brochure Specified", "No brochure was specified.")));

      var items = new[] { pageItemId };
      var generatedBrochure = new GenerateBrochureService().GenerateBrochure(brochureItem, items);
      if (generatedBrochure == null)
        return this.InfoMessage(InfoMessage.Error(DictionaryPhraseRepository.Current.Get("/Brochure/Print/File Generation Failed", "The personalised file could not be generated. Please try again.")));

      return File(generatedBrochure.Content, generatedBrochure.MimeType, generatedBrochure.Filename);
    }


    private IEnumerable<ID> GetBrochureItemIDs()
    {
      var brochureItems = brochureItemsRepository.Get();
      return brochureItems.Items.Any() ? brochureItems.Items.Select(i => i.ItemID) : null;
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
      if (item == null || !CheckAllowInBrochure(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, DictionaryPhraseRepository.Current.Get("/Brochure/Brochure Menu/Invalid Item", "This page cannot be added to the brochure. Please select a valid page."));

      var brochureItems = brochureItemsRepository.Get();
      if (!brochureItems.Add(item))
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, DictionaryPhraseRepository.Current.Get("/Brochure/Brochure Menu/Cannot Add", "This page has already been be added to the brochure, or cannot be added. Please select a valid page."));
      return View("_BrochureItems", brochureItems);
    }
  }
}