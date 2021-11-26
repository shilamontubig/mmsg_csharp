using System;
using BoDi;
using mmsg_csharp.Endpoints;
using Model.Data;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace mmsg_csharp.BDD.Steps {

    [Binding]
    public class LoginUserSteps : BaseSteps { 
    
        ApiBuilder api;
        public LoginUserSteps(IObjectContainer objectContainer) : base(objectContainer) {   
            this.api = new ApiBuilder();
        }

         [Then(@"A token will be returned")]
        public void ThenATokenWillBeReturned(){
            ResponseHandler r = new ResponseHandler();
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            Console.WriteLine("Response:   "+ response.Content);
            var userAccount = r.GetContent<UserAccount>(response);
            Assert.NotNull(userAccount.token, "No token was returned");
        }
    
    }
}