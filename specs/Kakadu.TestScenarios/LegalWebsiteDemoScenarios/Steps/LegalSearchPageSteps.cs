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
  public class LegalSearchPageSteps : StepsBase
  {
    [When(@"Actor clicks (.*) link on Search Results")]
    public void WhenActorClicksLinkOnSearchResults(string text)
    {
      LegalSearchPage.FirstSearchResults.First(el=>el.Text.Contains(text)).Click();
    }

  }
}
