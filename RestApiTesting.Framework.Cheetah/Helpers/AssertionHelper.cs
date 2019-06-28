using System.Dynamic;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Cheetah.Helpers
{
    public class AssertionHelper
    {
        public static void AssertModelMatchTable(ExpandoObject actualModel, ExpandoObject expectedModel)
        {
            actualModel.Should().BeEquivalentTo(expectedModel);
        }

        public static void AssertNoOfModelParameters(ScenarioContext scenarioContext, string responseBodyKey, int numExpectedParameters)
        {
            var responseBody = scenarioContext.Get<ExpandoObject>(responseBodyKey);
            responseBody.Should().HaveCount(numExpectedParameters);
        }

        public static void AssertStrings(string actual, string expected)
        {
            actual.Should().Be(expected);
        }
    }
}