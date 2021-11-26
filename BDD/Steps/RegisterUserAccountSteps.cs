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
    public class RegisterUserAccountSteps : BaseSteps {

        ApiBuilder api;
        public RegisterUserAccountSteps(IObjectContainer objectContainer) : base(objectContainer) {   
            this.api = new ApiBuilder();
        }

        [Given(@"An empty request body")]
        public void GivenAnEmptyRequest()
        {
            UserAccount userAccount = new UserAccount(null, null, null, null, null);
            this.objectContainer.RegisterInstanceAs<UserAccount>(userAccount,"UserAccount");
        }
        
        [Given(@"The following account details")]
        public void GivenTheFollowingAccountDetails(Table table)
        {
            var userAccount = table.CreateInstance<UserAccount>();
            this.objectContainer.RegisterInstanceAs<UserAccount>(userAccount,"UserAccount");
        }

        [When(@"I perform post request")]
        public void WhenIPerformPostRequest() {
            //create payload 
            ResponseHandler r = new ResponseHandler(); 
            var userAccount = this.objectContainer.Resolve<UserAccount>("UserAccount");
            var payload = userAccount.email == null && userAccount.password == null  ? "{}" : r.ConvertToJson(userAccount);
            
            //create request and get response
            RestClient restClient = objectContainer.Resolve<RestClient>("RestClient");
            var request = api.CreatePostRequest(payload);
            Console.WriteLine("Rquest:   "+ payload);
            var response = api.GetResponse(restClient, request);
            Console.WriteLine("Response:   "+ response.Content);
            
            //save response
            this.objectContainer.RegisterInstanceAs<IRestResponse>(response,"response");
        }

        [Then(@"An ID and token will be returned")]
        public void ThenAnIdAndTokenWillBeReturned(){
            ResponseHandler r = new ResponseHandler();
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            var userAccount = r.GetContent<UserAccount>(response);
            Assert.NotNull(userAccount.id, "No ID was returned");
            Assert.NotNull(userAccount.token, "No token was returned");
        }

        [Then(@"An error message (.*) will be displayed")]
        public void ThenAnErrorMessageWillBeDisplayed(string errorMsg){
            ResponseHandler r = new ResponseHandler();
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            Console.WriteLine("Response:   "+ response.Content);
            var userAccount = r.GetContent<UserAccount>(response);
            Assert.AreEqual(userAccount.error, errorMsg);
        }

    }

}