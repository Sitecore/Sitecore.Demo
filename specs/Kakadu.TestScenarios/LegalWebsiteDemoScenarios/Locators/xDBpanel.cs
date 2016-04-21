using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Extensions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class xDBpanel
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> OpenXDBSlidebar
      => Driver.WaitUntilElementsPresent(By.CssSelector(".btn.btn-info.sidebar-closed"));
  }
}
