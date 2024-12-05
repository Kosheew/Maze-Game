using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InitGame.Level
{
    public class WalletController : MonoBehaviour
    {
        private Wallet _wallet;
        private WalletView _walletView;

        public WalletController(Wallet wallet, WalletView walletView)
        {
            _wallet = wallet;
            _walletView = walletView;

            _wallet.OnKeyCountChanged += UpdateView;
            UpdateView(_wallet.MaxKeys, _wallet.MaxKeys);
        }

        private void UpdateView(int keyScore, int maxKeys)
        {
            _walletView.UpdateKeyText(keyScore, maxKeys);
        }
    }
}