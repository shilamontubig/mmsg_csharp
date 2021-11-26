using BoDi;

namespace mmsg_csharp.BDD.Steps
{

    public abstract class BaseSteps {
        protected IObjectContainer objectContainer;
 
        protected BaseSteps(IObjectContainer objectContainer) {
            this.objectContainer = objectContainer;
        }
    }
}
