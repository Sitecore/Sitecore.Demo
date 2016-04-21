using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Common;

namespace ClassLibrary1.Infrastructure
{
  public class Settings
  {
    public static string BaseUrl => ConfigurationManager.AppSettings["baseUrl"];

    public static string UserName => "sitecore\\admin";
    public static string Password => "b";

    public static string EndSessionUrl => BaseUrl + ConfigurationManager.AppSettings["endSessionUrl"];
    public static string UtfHelperService => BaseUrl + ConfigurationManager.AppSettings["utfProxyUrl"];

    public static string TestHelperService => BaseUrl + ConfigurationManager.AppSettings["testsProxyUrl"];

  }
}
