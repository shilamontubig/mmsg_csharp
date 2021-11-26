
using BoDi;
using Model.Data;
using TechTalk.SpecFlow;

namespace mmsg_csharp.BDD.Steps
{
    public class StepHooks {

        private readonly IObjectContainer objectContainer;
        
        public StepHooks(IObjectContainer objectContainer) {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Setup() {            
            objectContainer.RegisterInstanceAs<EnvConfiguration>(new EnvConfiguration());
        }
    }   
}