using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Brochure.Models
{
  using System.IO;

  public class Brochure
  {
    public Stream Content { get; set; }
    public String Filename { get; set; }
    public string MimeType { get; set; }
  }
}