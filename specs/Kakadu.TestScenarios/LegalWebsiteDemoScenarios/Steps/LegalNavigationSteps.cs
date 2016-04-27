using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Extensions;
using ClassLibrary1.Infrastructure;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Steps
{
    public class LegalNavigationSteps : StepsBase
  {
    [Given(@"Actor navigates to Home page")]
    [Given(@"Actor has opened Home page")]
    [Given(@"User has opened Legal website")]
    [Given(@"Legal website homepage is opened in private browsing session")]
    public void GivenLegalWebsiteHomepageIsOpenedInPrivateBrowsingSession()
    {
      NavigateToPage(Settings.BaseUrl);
    }

    [When(@"Actor navigates to the About-Us page")]
    public void WhenActorNavigatesToTheAbout_UsPage()
    {
      NavigateToPage(Settings.AboutUsUrl);
    }

        [Given(@"User has opened Corporate Finance page")]
        public void GivenUserHasOpenedCorporateFinancePage()
        {
            NavigateToPage(Settings.CorporateFinanceUrl);
        }

    [When(@"Actor navigates to Home page")]
    public void WhenActorNavigatesToHomePage()
    {
      NavigateToPage(Settings.BaseUrl);
    }

    [Given(@"Legal website is opened on the Taxation-Webinar-Register page")]
    public void GivenLegalWebsiteIsOpenedOnTheTaxation_Webinar_RegisterPage()
    {
      NavigateToPage(Settings.TaxationWebinarRegister);
    }


    [Given(@"Legal website is opened on the Legal/Email page")]
    public void GivenLegalWebsiteIsOpenedOnTheLegalEmailPage()
    {
      NavigateToPage(Settings.LegalEmailPage);
    }

    [Given(@"Legal website is opened on the Legal/Search page")]
    public void GivenLegalWebsiteIsOpenedOnTheLegalSearchPage()
    {
      NavigateToPage(Settings.LegalSearchPage);
    }


  }
}
