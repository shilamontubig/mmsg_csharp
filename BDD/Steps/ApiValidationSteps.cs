using System.Collections.Generic;
using BoDi;
using mmsg_csharp.Endpoints;
using Model.Data;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace mmsg_csharp.BDD.Steps {

[Binding]
    public class ApiValidationSteps : BaseSteps {
        ApiBuilder api;
        IDictionary<string, string> filter=null;
        
        public ApiValidationSteps(IObjectContainer objectContainer) : base(objectContainer) {
            
        }

        [Given(@"An Api (.*)")]
        public void GivenAnApi(string endpoint)
        {
            var config = objectContainer.Resolve<EnvConfiguration>();
            var baseUrl = config.baseUrl;
            api = new ApiBuilder();
            var restclient = api.SetUrl(baseUrl, endpoint);
            objectContainer.RegisterInstanceAs<RestClient>(restclient,"RestClient");
        }

        [Given(@"I add query params using the following")]
        public void GivenIAddQueryParamsUsingTheFollowing(Table table) {
            var tableUser = table.CreateInstance<UsersData>();
            //create filters
            filter = new Dictionary<string, string>();
            filter.Add(new KeyValuePair<string, string>("page", tableUser.page.ToString()));
            filter.Add(new KeyValuePair<string, string>("per_page", tableUser.per_page.ToString()));
        }

        [When(@"I perform a Get request")]
        public void WhenIPerformGetRequest()
        {
            RestClient restClient = objectContainer.Resolve<RestClient>("RestClient");
            RestRequest request = filter != null ? api.CreateGetRequest(filter) : api.CreateGetRequest(); 
            var response = api.GetResponse(restClient, request);
            this.objectContainer.RegisterInstanceAs<IRestResponse>(response,"response");
        }

        [Then(@"I get status (.*)")]
        public void ThenIGetStatus(int status_code)
        {
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            Assert.AreEqual((int)response.StatusCode, status_code);
        }

        [Then(@"I get an empty response")]
        public void ThenIGetAnEmptyResponse()
        {
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            if (response.Content == "{}" || response.Content == string.Empty) {
                Assert.IsTrue(true);    
            } else {
                Assert.IsTrue(false, "response is not empty");  
            }
        }
    }

}