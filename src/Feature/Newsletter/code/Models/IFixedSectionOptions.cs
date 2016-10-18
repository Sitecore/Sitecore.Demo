namespace Sitecore.Feature.Newsletter.Models
{
  using Sitecore.Data.Items;

  public interface IFixedSectionOptions
  {
    string BackgroundColor { get;  }
    string FontColor { get; }
    Item[] LinkItems { get; }
  }
}