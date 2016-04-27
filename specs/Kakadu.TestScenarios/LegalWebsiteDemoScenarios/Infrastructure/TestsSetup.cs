using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ClassLibrary1.Steps;
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

    [BeforeScenario("UI")]
    public static void Setup()
    {

      var firefoxProfile = new FirefoxProfile();
      firefoxProfile.SetPreference("browser.download.folderList", 2);


      firefoxProfile.SetPreference("browser.download.panel.shown", false);


      firefoxProfile.SetPreference("pdfjs.disabled", true);
      firefoxProfile.SetPreference("pdfjs.firstRun", false);

      firefoxProfile.SetPreference("browser.download.dir", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\downloads" );
      firefoxProfile.SetPreference("browser.helperApps.neverAsk.openFile", "application/pdf");
      firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");

      var webDriver = (IWebDriver)new FirefoxDriver(firefoxProfile);

      FeatureContext.Current.Set(webDriver); ;
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


    [AfterScenario]
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

    public static WhenActionSteps WhenActionSteps =>new WhenActionSteps();




  }
}
