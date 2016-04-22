using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Extensions;
using ClassLibrary1.Infrastructure;
using ClassLibrary1.Locators;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ClassLibrary1.Steps
{
  public class WhenActionSteps : StepsBase
  {
    [When(@"Actor clicks (.*) link")]
    public void WhenActorClicksLink(string link)
    {
      LegalHomePage.LinkButton.First(x => x.Text.Equals(link)).Click();
    }

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

    [When(@"Actor clicks (.*) button on form")]
    public void WhenActorClicksButtonOnForm(string button)
    {
      CommonLocators.LinkButton.Single(el =>el.GetAttribute("value") == button).Submit();
    }


  }
}
