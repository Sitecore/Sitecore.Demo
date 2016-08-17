namespace Sitecore.Feature.Newsletter.Controllers
{
  using System.Web.Mvc;
  using Sitecore.Feature.Newsletter.Repositories;
  using Sitecore.Mvc.Presentation;

  public class NewsletterController : Controller
  {
    private IViewModelRepository Repository { get; set; }

    public NewsletterController() : this(new ViewModelRepository())
    {
    }

    public NewsletterController(IViewModelRepository repository)
    {
      Repository = repository;
    }

    public ActionResult Footer()
    {
      return View(Repository.GetFixedSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult Header()
    {
      return View(Repository.GetFixedSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult ContentSection()
    {
      return View(Repository.GetSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult ImageSection()
    {
      return View(Repository.GetSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult ListSection()
    {
      return View(Repository.GetListSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult SingleCTASection()
    {
      return View(Repository.GetSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
    public ActionResult TwoColumnCTASection()
    {
      return View(Repository.GetListSectionViewModel(RenderingContext.Current.Rendering.Item, RenderingContext.Current.Rendering.Parameters));
    }
  }
}