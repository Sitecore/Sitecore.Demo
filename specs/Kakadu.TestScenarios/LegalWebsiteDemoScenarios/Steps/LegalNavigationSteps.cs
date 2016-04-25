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
        [Given(@"User has opened Legal website")]
        [Given(@"Legal website homepage is opened in private browsing session")]
        [When(@"User has opened Legal website")]
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

        [Given(@"User has opened Trust, Estate, and Tax Law page")]
        public void GivenUserHasOpenedTrustEstateAndTaxLawPage()
        {
            NavigateToPage(Settings.TrustEstateTaxLawUrl);
        }


        [When(@"Actor navigates to Home page")]
        public void WhenActorNavigatesToHomePage()
        {
            NavigateToPage(Settings.BaseUrl);
        }


    }
}
