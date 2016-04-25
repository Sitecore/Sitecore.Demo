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
    class xDbPanelActions : StepsBase
  {
        [Given(@"Actor selects (.*) slidebar")]
    [When(@"Actor selects (.*) slidebar")]
    public void WhenActorSelectsSlidebar(string button)
    {
      XdBpanel.OpenXdbSlidebar.First(el => el.GetAttribute("title").Contains(button)).Click();
    }

    [When(@"Actor expands (.*) header on xDB panel")]
        public void WhenActorExpandsEngagementHeaderOnXdbPanel(string header)
    {
      XdBpanel.XDBpanelHeader.First(x => x.GetAttribute("innerText").Contains(header)).Click();
    }

    [Then(@"Engagement plans section contains (.*)")]
    public void ThenEngagementPlansSectionContains(string label)
    {
      XdBpanel.EngagementPlansList.Any(el => el.Text == label).Should().BeTrue();
    }

    [Then(@"Engagement plan sate equals to (.*)")]
    public void ThenEngagementPlanSateEqualsTo(string label)
    {
      XdBpanel.EngagementPlanState.Any(el => el.Text == label).Should().BeTrue();
    }

    [Then(@"Personal Information section contains followind data")]
    public void ThenPersonalInformationSectionContainsFollowindData(Table table)
    {
      var fields = table.Rows.Select(x => x.Values.First());
      fields.All(f => XdBpanel.MediaBody.Any(x => x.Text == f)).Should().BeTrue();
    }

    [Then(@"Following information is present in the section")]
    public void ThenFollowingInformationIsPresentInTheSection(Table table)
    {
      var rows = table.Rows;
      foreach (var tableRow in rows)
      {
        foreach (var col in tableRow)
        {
          var mediaSection = XdBpanel.OnsiteBehaviorSections.First(x => x.FindElements(By.CssSelector(".media-title")).Any(el => el.Text.Contains(col.Key)));
          mediaSection.Text.Should().Contain(col.Value);
        }
      }

    }



  }
}
