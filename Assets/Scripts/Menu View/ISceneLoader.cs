using UnityEngine.UI;

namespace Menu_View
{
    public interface ISceneLoader
    {
        void LoadSceneAsync(int sceneIndex, Slider loadSlider);
    }
}