using UnityEngine;
using TMPro;

namespace InitGame.Level
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text keyText;
        
        public void UpdateKeyText(int keyScore, int maxKeys)
        {
            keyText.text = $"{keyScore}/ {maxKeys}";
        }
    }
}
