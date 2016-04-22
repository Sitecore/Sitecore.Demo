using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class ThankYouPage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IWebElement ThanksTextArea
      =>
        Driver.FindElement(By.CssSelector(".container.m-b-1 h1"));
  }
}
