using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data;
  using Sitecore.Data.Items;

  public interface ISectionViewModel
  {
    Item ContentItem { get; }
    ISectionOptions SectionOptions { get;  }
    INewsletterOptions NewsletterOptions { get; }
  }
}