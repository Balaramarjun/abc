using System.Diagnostics;
using global::Microsoft.VisualStudio.TestTools.UnitTesting;
using global::TechTalk.SpecFlow;

[TestClass]
public class Cmc_Engage_UIAutomation_SpecFlow_MSTestAssemblyHooks
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
        var currentAssembly = typeof(Cmc_Engage_UIAutomation_SpecFlow_MSTestAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunStart(currentAssembly);
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        var currentAssembly = typeof(Cmc_Engage_UIAutomation_SpecFlow_MSTestAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunEnd(currentAssembly);
    }
}
