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

        public static string AboutUsUrl => BaseUrl + ConfigurationManager.AppSettings["aboutUsUrl"];

        public static string TaxationWebinarRegister
        => BaseUrl + ConfigurationManager.AppSettings["TaxationWebinarRegister"];

      public static string TaxationWebinarMoreInfo
        => BaseUrl + ConfigurationManager.AppSettings["TaxationWebinarMoreInfo"];

        public static string UserName => "sitecore\\admin";
        public static string Password => "b";

        public static string EndSessionUrl => BaseUrl + ConfigurationManager.AppSettings["endSessionUrl"];
        public static string UtfHelperService => BaseUrl + ConfigurationManager.AppSettings["utfProxyUrl"];

        public static string TestHelperService => BaseUrl + ConfigurationManager.AppSettings["testsProxyUrl"];

        public static string CorporateFinanceUrl => BaseUrl + ConfigurationManager.AppSettings["CorporateFinanceUrl"];

        public static string TrustEstateTaxLawUrl => BaseUrl + ConfigurationManager.AppSettings["TrustEstateTaxLawUrl"];

        public static string LegalEmailPage => BaseUrl + ConfigurationManager.AppSettings["LegalEmailPage"];

        public static string LegalSearchPage => BaseUrl + ConfigurationManager.AppSettings["LegalSearchPage"];
    }
}
