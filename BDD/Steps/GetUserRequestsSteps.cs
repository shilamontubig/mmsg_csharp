using System.Linq;
using BoDi;
using Model.Data;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace mmsg_csharp.BDD.Steps {

    [Binding]
    
    public class GetUserRequestsSteps : BaseSteps {
        
        public GetUserRequestsSteps(IObjectContainer objectContainer) : base(objectContainer) {   
           
        }

        [Then(@"The following data are displayed")]
        public void ThenTheFollowingDataAreDisplayed(Table table)
        {
           ResponseHandler r = new ResponseHandler();
           var response = this.objectContainer.Resolve<IRestResponse>("response");
           var users = r.GetContent<UsersData>(response);
           this.objectContainer.RegisterInstanceAs<UsersData>(users,"Users");
           
           //comparison data
           var tableUser = table.CreateInstance<UsersData>();
           Assert.AreEqual(users.page, tableUser.page);
           Assert.AreEqual(users.per_page, tableUser.per_page);
           Assert.AreEqual(users.total, tableUser.total);
           Assert.AreEqual(users.total_pages, tableUser.total_pages);
        }

        [Then(@"Number of user data is equal to (.*)")]
        public void ThenTheNumberOfUserDataIsEqualTo(int perPageUser)
        {
           var users = this.objectContainer.Resolve<UsersData>("Users");
           Assert.AreEqual(users.Data.Count(), perPageUser);
        }

        [Then(@"The correct user data is displayed")]
        public void ThenTheCorrectUserDataIsDisplayed(Table table)
        {
            ResponseHandler r = new ResponseHandler();
            var response = this.objectContainer.Resolve<IRestResponse>("response");
            var user = r.GetContent<User>(response);
            table.CompareToInstance<UserDetails>(user.data);
        }
    }

}