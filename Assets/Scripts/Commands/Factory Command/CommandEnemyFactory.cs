using Character.Enemy;
using Character.Command;

namespace Commands
{
    public class CommandEnemyFactory: CommandCharacterFactory
    {
        public override void Inject(DependencyContainer container)
        {
            base.Inject(container);
        }
        public void CreateAttackCommand(IEnemy enemy)
        {
            ICommand attackCommand = new AttackCommand(Container, enemy);
            Invoker.SetCommand(attackCommand);
            Invoker.ExecuteCommands();
        }

        public void CreatePatrolledCommand(IEnemy enemy)
        {
            ICommand patrolledCommand = new PatrolledCommand(Container, enemy);
            Invoker.SetCommand(patrolledCommand);
            Invoker.ExecuteCommands();
        }

        public void CreateChasingCommand(IEnemy enemy)
        {
            ICommand chasingCommand = new ChasingCommand(Container, enemy);
            Invoker.SetCommand(chasingCommand);
            Invoker.ExecuteCommands();
        }

        public void CharacterIdleCommand(IEnemy enemy)
        {
            ICommand idleCommand = new IdleCommand(Container, enemy);
            Invoker.SetCommand(idleCommand);
            Invoker.ExecuteCommands();
        }
    }
}