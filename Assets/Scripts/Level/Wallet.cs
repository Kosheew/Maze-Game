using System;

namespace InitGame.Level
{
    public class Wallet
    {
        private int _countKey;

        public void AddKey()
        {
            _countKey++;
        }

        public int GetKey() => _countKey;
    }
}
