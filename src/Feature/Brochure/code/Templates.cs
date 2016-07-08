namespace Sitecore.Feature.Brochure
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct Brochure
    {
      public static readonly ID ID = new ID("{355C1B33-E05A-437C-B036-D82846215C92}");

      public struct Fields
      {
        public static readonly ID Title = new ID("{D643FE17-ED04-455A-8C3B-18BABF0869C5}");
        public static readonly ID Description = new ID("{3A9A48BA-DE47-4DE2-A8D7-25D44780D568}");
        public static readonly ID Image = new ID("{ED5A056D-E0B5-4E12-BCA8-1CDCF92080F8}");
        public static readonly ID PrintStudioProject = new ID("{20E38F7B-5A24-4D33-A7EC-55007E78E532}");
        public static readonly ID StaticDownload = new ID("{681376E7-326F-471D-B83E-82E113EA1CDB}");
      }
    }
    public struct AllowInBrochure
    {
      public static readonly ID ID = new ID("{E466F3AD-4F1B-49F6-93FE-A5E9F0B79644}");

      public struct Fields
      {
        public static readonly ID AllowInBrochure = new ID("{B5C41973-AF3F-4D7D-8551-5CC1EB37A616}");
      }
    }
  }
}