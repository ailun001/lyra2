using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using System;
using TechTalk.SpecFlow;

namespace lyra2.Hooks
{
    [Binding]
    public sealed class Hook1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            // Example of filtering hooks using tags. (in this case, this 'before scenario' hook will execute if the feature/scenario contains the tag '@tag1')
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=hooks#tag-scoping

            //TODO: implement logic that has to run before executing each scenario
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            // Example of ordering the execution of hooks
            // See https://docs.specflow.org/projects/specflow/en/latest/Bindings/Hooks.html?highlight=order#hook-execution-order

            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }

        //[AfterScenario]
        //public void AfterScenario()
        //{
        //    // Add a FeatureContext parameter to the class constructor if need be
        //    var driverService = featureContext.Get<ChromeDriverService>();
        //    var driver = _objectContainer.Resolve<IWebDriver>();

        //    try
        //    {
        //        if (driverService.ProcessId != default)
        //        {
        //            Trace.WriteLine("Attempting to kill web driver service process #" + driverService.ProcessId);

        //            var process = Process.GetByProcessId(driverService.ProcessId);

        //            process.Kill();
        //            Trace.WriteLine("   > Done killing process #" + driverService.ProcessId);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("Exception thrown when killing web driver service: " + ex);
        //    }

        //    try
        //    {
        //        driverService.Dispose();
        //        Trace.WriteLine("Web driver service disposed of.");
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.WriteLine("Exception thrown when disposing of web driver service: " + ex);
        //    }

        //    driver?.Close();
        //    driver?.Quit();
        //    driver?.Dispose();
        //}
    }
}