using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class LegalHomePage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> LinkButton
      => Driver.FindElements(By.CssSelector(".btn.btn-default"));



  }
}
