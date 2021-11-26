using System;
using BoDi;
using mmsg_csharp.Endpoints;
using Model.Data;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace mmsg_csharp.BDD.Steps {
    
    [Binding]
    public class CreateUserJobDetailsSteps : BaseSteps {
        ApiBuilder api;
        public CreateUserJobDetailsSteps(IObjectContainer objectContainer) : base(objectContainer) {   
            this.api = new ApiBuilder();
        }

        [Given(@"The following details")]
        public void GivenTheFollowingDetails(Table table)
        {
            var job = table.CreateInstance<JobDetails>();
            this.objectContainer.RegisterInstanceAs<JobDetails>(job,"JobDetails");
        }

        [When(@"I perform post JobDetail request")]
        public void WhenIPerformPostJobDetailRequest() {
            //create payload 
            ResponseHandler r = new ResponseHandler(); 
            var jobDetails = this.objectContainer.Resolve<JobDetails>("JobDetails");
            var payload = r.ConvertToJson(jobDetails);
            
            //create request and get response
            RestClient restClient = objectContainer.Resolve<RestClient>("RestClient");
            RestRequest request = api.CreatePostRequest(payload);
            var response = api.GetResponse(restClient, request);
            Console.WriteLine("Response:   "+ response.Content);
            
            //save response
            this.objectContainer.RegisterInstanceAs<IRestResponse>(response,"response");
        }

        [Then(@"An ID will be returned")]
        public void ThenAnIdWillBeReturned(){
            ResponseHandler r = new ResponseHandler();
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            Console.WriteLine("Response:   "+ response.Content);
            var jobDetails = r.GetContent<JobDetails>(response);
            Assert.NotNull(jobDetails.id, "No ID returned");
        }

    }
}