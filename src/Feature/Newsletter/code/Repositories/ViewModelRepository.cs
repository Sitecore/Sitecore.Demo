namespace Sitecore.Feature.Newsletter.Repositories
{
  using System;
  using System.Linq;
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;
  using Sitecore.Mvc.Presentation;

  class ViewModelRepository : IViewModelRepository
  {
    private readonly INewsletterOptionsRepository newsletterOptionsRepository;
    private readonly ISectionOptionsRepository newsletterSectionOptionsRepository;
    private readonly IFixedSectionOptionsRepository fixedSectionOptionsRepository;

    public ViewModelRepository() : this(new NewsletterOptionsRepository(), new SectionOptionsRepository(), new FixedSectionOptionsRepository())
    {
      
    }

    private ViewModelRepository(INewsletterOptionsRepository newsletterOptionsRepository, ISectionOptionsRepository newsletterSectionOptionsRepository, IFixedSectionOptionsRepository fixedSectionOptionsRepository)
    {
      this.newsletterOptionsRepository = newsletterOptionsRepository;
      this.newsletterSectionOptionsRepository = newsletterSectionOptionsRepository;
      this.fixedSectionOptionsRepository = fixedSectionOptionsRepository;
    }

    public ISectionViewModel GetSectionViewModel(Item contentItem, RenderingParameters parameters)
    {
      if (!contentItem.IsDerived(Templates.SectionContent.ID))
        throw new ArgumentException("Invalid rendering context. Datasource item must be of type Section Content");

      return new SectionViewModel()
             {
               ContentItem = contentItem,
               NewsletterOptions = newsletterOptionsRepository.Get(contentItem),
               SectionOptions = newsletterSectionOptionsRepository.Get(parameters)
             };
    }

    public IListSectionViewModel GetListSectionViewModel(Item contentItem, RenderingParameters parameters)
    {
      return new ListSectionViewModel()
      {
        ParentItem = contentItem,
        Items = contentItem.Children.Where(c => c.IsDerived(Templates.SectionContent.ID)).ToArray(),
        NewsletterOptions = newsletterOptionsRepository.Get(contentItem),
        SectionOptions = newsletterSectionOptionsRepository.Get(parameters)
      };
    }

    public ISectionViewModel GetFixedSectionViewModel(Item item, RenderingParameters parameters)
    {
      if (!item.IsDerived(Templates.FixedSection.ID))
        throw new ArgumentException("Invalid rendering context. Datasource item must be of type Fixed Section Content");

      return new SectionViewModel()
      {
        ContentItem = item,
        NewsletterOptions = newsletterOptionsRepository.Get(item),
        SectionOptions = newsletterSectionOptionsRepository.Get(parameters)
      };
    }
  }
}