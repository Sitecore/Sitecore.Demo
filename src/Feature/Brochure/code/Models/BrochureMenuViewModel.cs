namespace Sitecore.Feature.Brochure.Models
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;

  public class BrochureMenuViewModel
  {
    public Item AddToBrochureItem { get; set; }
    public Item BrochureItem { get; set; }
    public IBrochureItems Items { get; set; }
    public bool AllowCurrentItemInBrochure { get; set; }
  }
}