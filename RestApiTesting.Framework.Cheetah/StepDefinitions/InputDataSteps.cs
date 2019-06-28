using System.Dynamic;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Cheetah.StepDefinitions
{
    [Binding]
    public sealed class InputDataSteps : Steps
    {
        private readonly ScenarioContext m_scenarioContext;

        public InputDataSteps(ScenarioContext scenarioContext)
        {
            m_scenarioContext = scenarioContext;
        }

        [When(@"I get the content ""(.*)"" of the response ""(.*)""")]
        public void WhenIGetTheContentOfTheResponse(string key, string responseMessageKey)
        {
            var responseMessage = m_scenarioContext.Get<HttpResponseMessage>(responseMessageKey);
            ExpandoObject contentObject = responseMessage.Content.ReadAsAsync<ExpandoObject>().GetAwaiter().GetResult();
            ScenarioContext.Add(key, contentObject);
        }

        [Given(@"I have a model ""(.[a-zA-Z0-9]+)"" with the following values:")]
        public void GivenIHaveAModelWithTheFollowingValues(string key, ExpandoObject model)
        {
            ScenarioContext.Add(key, model);
        }

        [Given(@"I have a string ""(.*)"" named ""(.*)""")]
        public void GivenIHaveAStringNamed(string value, string key)
        {
            ScenarioContext.Add(key, value);
        }

        [Given(@"I have an int ""(.*)"" named ""(.*)""")]
        public void GivenIHaveAIntNamed(int value, string key)
        {
            ScenarioContext.Add(key, value);
        }
    }
}