using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Newsletter
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct Link
    {
      public static ID ID = new ID("{803B2C82-1AA3-47BE-B00F-F48FD78DBCD8}");

      public struct Fields
      {
        public static ID Link = new ID("{7C79FF2C-9E24-4055-BCD2-F1E72093409F}");
      }
    }

    public struct SectionContent
    {
      public static ID ID = new ID("{67E66179-1E97-49CF-B58F-056F5250731D}");

      public struct Fields
      {
        public static ID Image = new ID("{18B3EF15-EC40-46FE-B03D-26CB3DB243CB}");
        public static ID Heading = new ID("{1CF3991C-C953-441C-8FE0-0BF26AF4B560}");
        public static ID Content = new ID("{94D50F81-F040-4B51-B895-D2FD2C27C223}");
        public static ID Link = new ID("{2E2C5FB3-FF5B-4F13-AA18-CFBA9C9A97D3}");
      }
    }

    public struct NewsletterOptions
    {
      public static ID ID = new ID("{3B0EEF2E-9DE6-4BDD-A9E9-93CF1A88D3D1}");

      public struct Fields
      {
        public static ID FontFamily = new ID("{1B417F04-7923-4826-B999-5B064D4EAA57}");
        public static ID HeadingFontSize = new ID("{EB627ABE-E800-41F9-90F8-82435F287243}");
        public static ID ContentFontSize = new ID("{CB3D04A8-B195-4F13-AB0B-B8C320AC66D5}");
        public static ID MaxWidth = new ID("{CB3D04A8-B195-4F13-AB0B-B8C320AC66D5}");
        public static ID BeforeBodyHtml = new ID("{4BAFEC3D-21BB-4278-9DF0-7D66C137BDEB}");
        public static ID AfterBodyHtml = new ID("{F97BD30F-D579-419F-9656-2972ACB68DC6}");
      }
    }

    public struct Header
    {
      public static ID ID = new ID("{CAA4BB30-BE8D-4482-8B7B-599F27B8B580}");

      public struct Fields
      {
        public static ID Logo = new ID("{2FAC8D4A-25FF-46CC-B2FF-A46E996D2913}");
      }
    }

    public struct Footer
    {
      public static ID ID = new ID("{3FA340E1-9F47-4D44-B1B9-00F1C425147E}");

      public struct Fields
      {
        public static ID LegalFooterText = new ID("{7224F1E8-7DCA-41AC-B2CF-E32DEA2DD077}");
      }
    }

    public struct NewsletterSectionParameters
    {
      public struct RenderingParameters
      {
        public const string BackgroundColor = "Background Color";
        public const string HeadingFontColor = "Heading Font Color";
        public const string ContentFontColor = "Content Font Color";
        public const string LinkColor = "Link Color";
      }
    }

    internal struct FixedSection
    {
      public static ID ID = new ID("{E7293BBD-8FFB-41A7-AF0D-1D92379BCDDC}");
      public struct Fields
      {
        public static ID BackgroundColor = new ID("{4BA95567-E774-48A4-967A-1BDEBF71B7E1}");
        public static ID FontColor = new ID("{332BBFBB-47B2-4FDE-9EA3-DB800B586437}");
      }
    }
  }
}