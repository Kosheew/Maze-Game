using UnityEngine;
using TMPro;

namespace Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TMP_Text keyText;
        
        public void UpdateKeyText(int keyScore, int maxKeys)
        {
            keyText.SetText($"{keyScore} / {maxKeys}");
        }
    }
}
