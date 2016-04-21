using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.HelperService;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Infrastructure
{
  public class ContextExtensions
  {
    public static List<TestCleanupAction> CleanupPool
    {
      get
      {
        if (!ScenarioContext.Current.ContainsKey("cleanup"))
        {
          ScenarioContext.Current.Add("cleanup", new List<TestCleanupAction>());
        }

        return ScenarioContext.Current.Get<List<TestCleanupAction>>("cleanup");
      }
    }

    public static AutoTestsHelperServiceSoapClient.AutoTestsHelperServiceSoapClient HelperService => new AutoTestsHelperServiceSoapClient.AutoTestsHelperServiceSoapClient(new BasicHttpBinding(), new EndpointAddress(Settings.TestHelperService));
    public static HelperWebServiceSoapClient UtfService => new HelperWebServiceSoapClient(new BasicHttpBinding(), new EndpointAddress(Settings.UtfHelperService));
  }
}
