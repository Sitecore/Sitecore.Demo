using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace ClassLibrary1.Infrastructure
{
  [Binding]
  public class TestsSetup
  {
    [BeforeStep]
    public static void Timeout()
    {
#warning shitcode
      Thread.Sleep(3000);
    }

    [BeforeFeature("UI")]
    public static void Setup()
    {
      FeatureContext.Current.Set((IWebDriver)new FirefoxDriver()); ;
    }

    [AfterScenario]
    public void Cleanup()
    {
      ContextExtensions.CleanupPool.ForEach(CleanupExecute);
    }

    private static void CleanupExecute(TestCleanupAction payload)
    {
      if (payload.ActionType == ActionType.RemoveUser)
      {
        ContextExtensions.HelperService.DeleteUser(payload.GetPayload<string>());
        return;
      }
      if (payload.ActionType == ActionType.CleanFieldValue)
      {
        var fieldPayload = payload.GetPayload<EditFieldPayload>();
        ContextExtensions.UtfService.EditItem(fieldPayload.ItemIdOrPath, fieldPayload.FieldName, fieldPayload.FieldValue, Settings.UserName, Settings.Password, fieldPayload.Database);
        return;
      }

      if (payload.ActionType == ActionType.DeleteItem)
      {
        var fieldPayload = payload.GetPayload<EditFieldPayload>();
        ContextExtensions.UtfService.DeleteItem(fieldPayload.ItemIdOrPath, fieldPayload.Database, false);
        return;
      }

      throw new NotSupportedException($"Action type '{payload.ActionType}' is not supported");
    }


    [AfterFeature]
    public static void TeardownTest()
    {
      try
      {
        FeatureContext.Current.Get<IWebDriver>().Quit();
      }
      catch (Exception)
      {
        // Ignore errors if unable to close the browser
      }
    }

    private static Settings Settings => new Settings();




  }
}
