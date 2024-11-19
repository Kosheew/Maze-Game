
namespace Commands
{
    public abstract class CommandCharacterFactory
    {
        protected CommandInvoker Invoker;
        protected DependencyContainer Container;

        public virtual void Inject(DependencyContainer container)
        {
            Invoker = container.Resolve<CommandInvoker>();
            Container = container;
        }

    }
}