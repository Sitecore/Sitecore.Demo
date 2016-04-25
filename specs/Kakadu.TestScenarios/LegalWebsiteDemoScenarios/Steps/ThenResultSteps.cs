using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Infrastructure;
using ClassLibrary1.Locators;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
  [Binding]
  public class ThenResultSteps: StepsBase
  {
    [Then(@"(.*) form with following fields is opened:")]
    public void ThenFormWithFollowingFieldsIsOpened(string formTitle, Table table)
    {
      var fields = table.Rows.Select(x => x.Values.First());
      fields.All(f => TaxationWebinarMoreInfoPage.FormFieldNames.Any(x =>x.Text == f)).Should().BeTrue();

      TaxationWebinarMoreInfoPage.FormTitle.Any(el => el.Text.Equals(formTitle)).Should().BeTrue();

    }

    [Then(@"(.*) page is opened")]
    public void ThenPageIsOpened(string url)
    {
      Driver.Url.Contains(Settings.BaseUrl+url).Should().BeTrue();
    }

    [Then(@"(.*) title presents")]
    public void ThenTitlePresents(string title)
    {
      var text = title;
      ThankYouPage.ThanksTextArea.Text.Contains(text).Should().BeTrue();
    }

    [Then(@"Following registration text presents:")]
    public void ThenFollowingRegistrationTextPresents(Table table)
    {
      var tableRows = table.Rows.First();
      var text = tableRows.First().Value;
      ThankYouPage.ThanksTextArea.Text.Contains(text).Should().BeTrue();
    }

    [Then(@"(.*) link available in the Carousel")]
    public void ThenLinkAvailableInTheCarousel(string button)
    {      
      HomePage.WebinarRegistrationButton.Displayed.Should().BeTrue();
      HomePage.WebinarRegistrationButton.Text.Equals(button).Should().BeTrue();
    }

    [Then(@"Taxation Webinar Register form fields contain following data")]
    public void ThenTaxationWebinarRegisterFormFieldsContainFollowingData(Table table)
    {
      
    }


  }
}
