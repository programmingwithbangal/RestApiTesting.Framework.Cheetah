using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using TechTalk.SpecFlow;

namespace RestApiTesting.Framework.Cheetah.Helpers
{
    [Binding]
    public sealed class TransformerHelper
    {
        private readonly ScenarioContext m_scenarioContext;

        public TransformerHelper(ScenarioContext scenarioContext)
        {
            m_scenarioContext = scenarioContext;
        }

        [StepArgumentTransformation]
        public ExpandoObject GetExpandoObject(object input)
        {
            dynamic model = new ExpandoObject();
            switch (input)
            {
                case Table inputTable:
                    foreach (TableRow row in inputTable.Rows)
                    {
                        ((IDictionary<string, object>)model).Add(row["Field"], m_scenarioContext.Get<object>(row["Value"]));
                    }

                    break;
                case string inputString:
                    model = m_scenarioContext.Get<ExpandoObject>(inputString);
                    break;
                default:
                    throw new ArgumentException($"No StepArgumentTransformation exists from type {input.GetType()} to type ExpandoObject");
            }

            return model;
        }

        [StepArgumentTransformation]
        public HttpClient GetHttpClient(string clientKey)
        {
            return m_scenarioContext.Get<HttpClient>(clientKey);
        }

        [StepArgumentTransformation]
        public HttpResponseMessage GetResponseMessage(string responseKey)
        {
            return m_scenarioContext.Get<HttpResponseMessage>(responseKey);
        }

        public static object GetActualValue(ScenarioContext scenarioContext, string field, string objectKey)
        {
            var content = scenarioContext.Get<ExpandoObject>(objectKey);
            IDictionary<string, object> contentDict = content;
            contentDict.TryGetValue(field, out object actualValue);
            return actualValue;
        }
    }
}