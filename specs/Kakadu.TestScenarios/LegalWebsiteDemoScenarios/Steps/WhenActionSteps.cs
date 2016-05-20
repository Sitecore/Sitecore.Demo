using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Extensions;
using ClassLibrary1.Infrastructure;
using ClassLibrary1.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ClassLibrary1.Steps
{
  public class WhenActionSteps : StepsBase
  {
    [Given(@"Actor clicked (.*) link")]
    [When(@"Actor clicks (.*) link")]
    public void WhenActorClicksLink(string link)
    {
      LegalHomePage.LinkButton.First(x => x.Text.Equals(link)).Click();
    }

    [When(@"Actor clicks (.*) link and opens PDF")]
    public void WhenActorClicksLinkAndOpensPDF(string link)
    {
      var url = CommonLocators.LinkButton.First(x => x.Text == link).GetAttribute("href");
      NavigateToPage(Settings.BaseUrl + url);
    }

    [Given(@"Actor enters following data in to the (.*) form fields")]
    [When(@"Actor enters following data in to the (.*) form fields")]
    public void WhenActorEntersFollowingDataInToTheFormFields(string formTitle, Table table)
    {
      foreach (var row in table.Rows)
      {

        foreach (var column in row)
        {
          TaxationWebinarMoreInfoPage.FormFields
     .First(x => x.FindElement(By.TagName("label")).Text == column.Key)
     .FindElement(By.ClassName("text-box")).SendKeys(column.Value);
        }
      }
    }

    [Given(@"Actor clicked (.*) button on form")]
    [When(@"Actor clicks (.*) button on form")]
    public void WhenActorClicksButtonOnForm(string button)
    {
      CommonLocators.LinkButton.Single(el =>el.GetAttribute("value") == button).Submit();
    }

    [When(@"Actor clicks (.*) button on Carousel")]
    public void WhenActorClicksButtonOnCarousel(string button)
    {
      HomePage.WebinarRegistrationButton.Click();
    }


    [Given(@"Actor enters followind data into form fields")]
    [When(@"Actor enters followind data into form fields")]
    public void WhenActorEntersFollowindDataIntoFormFields(Table table)
    {
      foreach (var row in table.Rows)
      {

        foreach (var column in row)
        {
          TaxationWebinarRegisterPage.FormFields
     .First(x => x.FindElement(By.TagName("label")).Text == column.Key)
     .FindElement(By.ClassName("text-box")).SendKeys(column.Value);
        }
      }
    }

    [Given(@"Actor clicks (.*) button")]
    [When(@"Actor clicks (.*) button")]
    public void WhenActorClicksButton(string button)
    {
      CommonLocators.LinkButton.First(x => x.GetAttribute("value")==button).Click();
    }

    [Given(@"Actor sets Month Preference combobox to (.*)")]
    [When(@"Actor sets Month Preference combobox to (.*)")]
    public void WhenActorSetsMonthPreferenceComboboxToSomeMonth(string month)
    {
      var dropDownListBox = TaxationWebinarRegisterPage.MonthPreferenceDropDown;
      var clickThis = new SelectElement(dropDownListBox);
      clickThis.SelectByText(month);
    }

    [When(@"Actor clicks Register now link on Legal/Email page")]
    public void WhenActorClicksRegisterNowLinkOnLegalEmailPage()
    {
      LegalEmailPage.Link.Click();
    }


  }
}
