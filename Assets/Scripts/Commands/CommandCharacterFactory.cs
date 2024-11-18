
namespace Commands
{
    public class CommandCharacterFactory
    {
        protected readonly CommandInvoker Invoker;
        protected readonly DependencyContainer Container;

        protected CommandCharacterFactory(DependencyContainer container)
        {
            Invoker = container.Resolve<CommandInvoker>();
            Container = container;
        }

    }
}