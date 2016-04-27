using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Infrastructure;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Extensions
{
  [Binding]
  public static class SeleniumExtensions 
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();
    public static IWebElement GetField(this IEnumerable<IWebElement> elements, string formField)
    {
      return elements.First(x => x.GetAttribute("name") == formField);
    }

    public static IWebElement GetValue(this IEnumerable<IWebElement> elements, string formValue)
    {
      return elements.First(x => x.GetAttribute("value") == formValue);
    }

    public static IWebElement GetType(this IEnumerable<IWebElement> elements, string formType)
    {
      return elements.First(x => x.GetAttribute("value") == formType);
    }

    public static IWebElement WaitUntilElementPresent(this IWebDriver driver, By selector)
    {
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
      wait.Until(ExpectedConditions.ElementExists(selector));

      return driver.FindElement(selector);
    }

    public static IEnumerable<IWebElement> WaitUntilElementsPresent(this IWebDriver driver, By selector)
    {
      var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
      wait.Until(ExpectedConditions.ElementExists(selector));

      return driver.FindElements(selector);
    }
  }
}
