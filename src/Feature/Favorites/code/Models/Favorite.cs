namespace Sitecore.Feature.Favorites.Models
{
  using Sitecore.Data;

  public class Favorite
  {
    public string Title { get; set; }
    public ID ItemID { get; set; }
    public string ItemUrl { get; set; }
  }
}