using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class LegalSearchPage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> FirstSearchResults
      => Driver.FindElements(By.CssSelector("#vs0p1"));
  }
}
