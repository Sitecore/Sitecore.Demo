using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Infrastructure
{
  [Binding]
  public class StepsBase
  {
    public static IWebDriver Driver
    {
      get
      {
        return FeatureContext.Current.Get<IWebDriver>();
      }
      set
      {
        FeatureContext.Current.Set(value);
      }
    }

    public static Actions DriverActions
    {
      get { return FeatureContext.Current.Get<Actions>(); }

      set { FeatureContext.Current.Set(value); }
    }

    public static void NavigateToPage(string url)
    {
      Driver.Navigate().GoToUrl(url);
    }

  }
}
