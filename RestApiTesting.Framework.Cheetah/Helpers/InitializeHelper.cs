using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Cheetah.Helpers
{
    [Binding]
    public sealed class InitializeHelper
    {
        public ScenarioContext ScenarioContext;

        public InitializeHelper(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ConfigurationHelper.BuildConfiguration();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ScenarioContext.Add(nameof(ConfigurationHelper.TestApiUrl), ConfigurationHelper.TestApiUrl);
        }
    }
}