using System.Dynamic;
using System.Net.Http;
using System.Text.RegularExpressions;
using RestApiTesting.Framework.Cheetah.Helpers;
using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Cheetah.StepDefinitions
{
    [Binding]
    public sealed class ResponseAssertionsSteps : Steps
    {
        private readonly ScenarioContext m_scenarioContext;

        public ResponseAssertionsSteps(ScenarioContext scenarioContext)
        {
            m_scenarioContext = scenarioContext;
        }

        [Then(@"the model ""(.*)"" should have (.*) parameters")]
        public void AndTheModelShouldHaveParameters(string responseBodyKey, int numExpectedParameters)
        {
            AssertionHelper.AssertNoOfModelParameters(m_scenarioContext, responseBodyKey, numExpectedParameters);
        }

        [Then(@"the model ""(.*)"" should match the following values:")]
        public void ThenTheModelShouldMatchTheFollowingValues(string actualModelKey, ExpandoObject expectedModel)
        {
            var actualModel = m_scenarioContext.Get<ExpandoObject>(actualModelKey);
            AssertionHelper.AssertModelMatchTable(actualModel, expectedModel);
        }

        [Then(@"the response ""(.*)"" should have the status code ""(.*)""")]
        public void ThenTheResponseShouldHaveTheStatusCode(HttpResponseMessage response, string expectedStatusCode)
        {
            AssertionHelper.AssertStrings(response.ReasonPhrase, expectedStatusCode);
        }

        [Then(@"I compare ""(.*)"" of ""(.*)"" with ""(.*)""")]
        public void ThenICompareOfWith(string field, string objectKey, string expectedValueKey)
        {
            var expectedValue = m_scenarioContext.Get<object>(expectedValueKey);
            object actualValue = TransformerHelper.GetActualValue(m_scenarioContext, field, objectKey);

            string expectedValueFixed = Regex.Replace(expectedValue.ToString(), @"\s+", string.Empty);
            string actualValueFixed = Regex.Replace(actualValue.ToString(), @"\s+", string.Empty);
            AssertionHelper.AssertStrings(actualValueFixed, expectedValueFixed);
        }

        [Then(@"the modified ""(.*)"" of ""(.*)"" should be modified ""(.*)""")]
        public void ThenTheModifiedOfShouldBeModified(string field, string objectKey, string expectedValueKey)
        {
            var expectedValue = m_scenarioContext.Get<object>(expectedValueKey);
            object actualValue = TransformerHelper.GetActualValue(m_scenarioContext, field, objectKey);

            string expectedValueFixed = Regex.Replace(expectedValue.ToString(), @"\s+", string.Empty);
            string actualValueFixed = Regex.Replace(actualValue.ToString(), @"\s+", string.Empty);
            AssertionHelper.AssertStrings(actualValueFixed, expectedValueFixed);
        }

        [Then(@"the ""(.*)"" of ""(.*)"" should be ""(.*)""")]
        public void ThenTheOfShouldBe(string field, string objectKey, string expectedValueKey)
        {
            var expectedValue = m_scenarioContext.Get<object>(expectedValueKey);
            object actualValue = TransformerHelper.GetActualValue(m_scenarioContext, field, objectKey);
            AssertionHelper.AssertStrings(actualValue.ToString(), expectedValue.ToString());
        }
    }
}