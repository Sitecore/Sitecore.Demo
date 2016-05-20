using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class LegalEmailPage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IWebElement Link
      => Driver.FindElement(By.CssSelector(".article.body>h5>a"));

  }
}
