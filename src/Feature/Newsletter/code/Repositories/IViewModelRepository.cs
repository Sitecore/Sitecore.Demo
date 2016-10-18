using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Newsletter.Repositories
{
  using Sitecore.Data.Items;
  using Sitecore.Feature.Newsletter.Models;
  using Sitecore.Mvc.Presentation;

  public interface IViewModelRepository
  {
    ISectionViewModel GetSectionViewModel(Item contentItem, RenderingParameters parameters);
    IListSectionViewModel GetListSectionViewModel(Item contentItem, RenderingParameters parameters);
    ISectionViewModel GetFixedSectionViewModel(Item item, RenderingParameters parameters);
  }
}