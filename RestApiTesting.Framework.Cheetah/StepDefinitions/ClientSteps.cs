using System;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using RestApiTesting.Framework.Cheetah.Helpers;

namespace RestApiTesting.Framework.Cheetah.StepDefinitions
{
    [Binding]
    public sealed class ClientSteps : Steps
    {
        private readonly ScenarioContext m_scenarioContext;

        public ClientSteps(ScenarioContext scenarioContext)
        {
            m_scenarioContext = scenarioContext;
        }

        [When(@"I send a ""([^""]*)"" request to ""([^""]*)"" using client ""([^""]*)"" and get the response ""([^""]*)""")]
        public async Task WhenISendARequestToUsingClientAndGetTheResponse(string apiRequestType, string uri, HttpClient client, string responseKey)
        {
            HttpResponseMessage response = await ClientHelper.GetResponse(uri, apiRequestType, client, null);
            m_scenarioContext.Add(responseKey, response);
        }

        [When(@"I send a ""([^""]*)"" request to ""([^""]*)"" with model ""([^""]*)"" using client ""([^""]*)"" and get the response ""([^""]*)""")]
        public async Task WhenISendARequestToWithModelUsingClientAndGetTheResponse(string apiRequestType, string uri, string modelKey, string clientKey, string responseKey)
        {
            var model = m_scenarioContext.Get<ExpandoObject>(modelKey);
            var client = m_scenarioContext.Get<HttpClient>(clientKey);
            HttpResponseMessage response = await ClientHelper.GetResponse(uri, apiRequestType, client, model);
            m_scenarioContext.Add(responseKey, response);

        }

        [Given(@"I have a client ""(.*)""")]
        public void GivenIHaveAClient(string httpClientKey)
        {
            var uri = new Uri(ConfigurationHelper.TestApiUrl);
            HttpClient client = ClientHelper.GetClient(uri);
            m_scenarioContext.Add(httpClientKey, client);
        }
    }
}