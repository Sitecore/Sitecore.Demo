using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Infrastructure;
using ClassLibrary1.Locators;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
  class xDbPanelActions: StepsBase
  {
    [When(@"Actor selects (.*) slidebar")]
    public void WhenActorSelectsSlidebar(string button)
    {
      XdBpanel.OpenXdbSlidebar.First(el => el.GetAttribute("title").Contains(button)).Click();
    }

    [When(@"Actor expands (.*) header on xDB panel")]
    public void WhenActorExpandsEngagementHeaderOnXDBPanel(string header)
    {
      XdBpanel.XDBpanelHeader.First(el => el.Text.Equals(header)).Click();
    }

  }
}
