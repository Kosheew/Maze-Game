using UnityEngine.UI;

namespace Menu_View
{
    public interface IMainPresenter
    {
        void StartGame(Slider slider);
        void ExitGame();
    }
}