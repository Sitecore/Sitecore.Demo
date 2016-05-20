using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Locators
{
  public class TaxationWebinarRegisterPage
  {
    public static IWebDriver Driver => FeatureContext.Current.Get<IWebDriver>();

    public static IEnumerable<IWebElement> FormFieldSection
      =>
        Driver.FindElements(By.CssSelector("form[data-wffm] div.form-group"));

    public static IEnumerable<IWebElement> FormFields
      =>
        Driver.FindElements(By.CssSelector
          (".required-field.form-group"));

    public static IWebElement MonthPreferenceDropDown
      => Driver.FindElement(By.CssSelector("#wffma025532010144f978db4dc4a3efb3336_Sections_0__Fields_3__Value"));

  }
}
