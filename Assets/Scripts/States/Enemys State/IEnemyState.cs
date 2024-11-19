using Character.Enemy;

namespace Character
{
    public interface IEnemyState
    {
        void EnterState(IEnemy enemy);
        void UpdateState(IEnemy enemy);
        void ExitState(IEnemy enemy);
    }
}
