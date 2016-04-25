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
  
  public class XdBpanel
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> OpenXdbSlidebar
      => 
      Driver.WaitUntilElementsPresent(By.CssSelector(".btn.btn-info.sidebar-closed"));

    public static IEnumerable<IWebElement> XDBpanelHeader
      => Driver.WaitUntilElementsPresent(By.CssSelector("a.panel-title"));

    public static IEnumerable<IWebElement> EngagementPlansList
      => Driver.FindElements(By.CssSelector(".table.table-condensed.table-borderless>tbody>tr>td>small"));

    public static IEnumerable<IWebElement> EngagementPlanState
      => Driver.FindElements(By.CssSelector(".table.table-condensed.table-borderless>tbody>tr>td"));

    public static IEnumerable<IWebElement> MediaBody
      => Driver.FindElements(By.CssSelector(".media-body>dl>dd"));

   public static  IWebElement OnsiteBehavior
      => Driver.FindElement(By.CssSelector("#onsiteBehaviorPanel"));

    public static IEnumerable<IWebElement> OnsiteBehaviorSections
      => XdBpanel.OnsiteBehavior.FindElements(By.CssSelector(".media"));



  }
}
