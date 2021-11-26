using System;
using BoDi;
using mmsg_csharp.Endpoints;
using RestSharp;
using TechTalk.SpecFlow;

namespace mmsg_csharp.BDD.Steps {
    
    [Binding]
    public class DeleteUserSteps : BaseSteps {
        ApiBuilder api;
        public DeleteUserSteps(IObjectContainer objectContainer) : base(objectContainer) {   
            this.api = new ApiBuilder();
        }

        [When(@"I perform delete request")]
        public void WhenIPerformDeleteRequest(){
            RestClient restClient = objectContainer.Resolve<RestClient>("RestClient");
            RestRequest request = api.CreateDeleteRequest();
             var response = api.GetResponse(restClient, request);
            Console.WriteLine("Response:   "+ response.Content);
            
            //save response
            this.objectContainer.RegisterInstanceAs<IRestResponse>(response,"response");
        }
    }
}