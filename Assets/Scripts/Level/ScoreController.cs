using System;

namespace InitGame.Level
{
    public class ScoreController
    {
        private int _score; 

        public void Init()
        {
           
        }


        private void OnScoreAdded()
        {
            _score++; 
            
        }

    }
}
