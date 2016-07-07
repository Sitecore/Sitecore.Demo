using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.Print
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct ParagraphStyle
    {
      public static readonly ID ID = new ID("{013A39C1-6F18-445C-9E5F-70ED2D4646D7}");

      public struct Fields
      {
        public static readonly ID Style = new ID("{96878C4C-2E2D-4D16-8EE4-6C4895132AA9}");
      }
    }

    public struct DataReference
    {
      public static readonly ID ID = new ID("{CFB76D37-7B86-4375-B7D1-D0D3BEEBB1CF}");
      public struct Fields
      {
        public static readonly ID ItemReference = new ID("{34B8300B-A942-482B-A5C7-50CEF63AA71C}");
        public static readonly ID ItemField = new ID("{65CE9A56-FED3-4D16-8EA6-EA781ABC5C27}");
        public static readonly ID ItemSelector = new ID("{C96407B7-2B4B-4F53-80D1-2302895E9057}");
        public static readonly ID DataKey = new ID("{DF94A83F-2B11-4DC6-9737-DFCB4D6FACEF}");
        public static readonly ID SearchQuery = new ID("{329E3738-A957-4442-A231-F35C38943DA8}");
      }
    }

    public struct P_Snippet
    {
      public static readonly ID ID = new ID("{E7E439E8-C699-4608-AC77-CC6273702E54}");
      public struct Fields
      {
        public static readonly ID DataKey = new ID("{6A937E7B-992E-4B75-A822-EDA1CD0445E3}");
      }
    }
  }
}