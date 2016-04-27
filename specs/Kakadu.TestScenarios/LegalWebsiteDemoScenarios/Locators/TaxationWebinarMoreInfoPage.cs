using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{

  public class TaxationWebinarMoreInfoPage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> FormTitle 
      =>
      Driver.FindElements(By.CssSelector(".page-header h1"));

    public static IEnumerable<IWebElement> FormFieldNames
      =>
        Driver.FindElements(By.CssSelector(".control-label"));

    public static IEnumerable<IWebElement> FormFields
      =>
        Driver.FindElements(By.CssSelector
          (".required-field.form-group"));


  }
}
