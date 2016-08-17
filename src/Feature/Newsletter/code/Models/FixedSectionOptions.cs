namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data.Items;

  class FixedSectionOptions : IFixedSectionOptions
  {
    public string BackgroundColor { get; set; }
    public string FontColor { get; set; }
    public Item[] LinkItems { get; set; }
  }
}