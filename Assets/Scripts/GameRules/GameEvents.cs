using System;
using UnityEngine;

namespace GameRules
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents singleton;
        public event Action onPlayerMunch, onResetGame;

        private void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
            }
        }


        public void PlayerMunch()
        {
            if (onPlayerMunch != null)
            {
                onPlayerMunch();
            }
        }

        public void ResetGame()
        {
            if (onResetGame != null)
            {
                onResetGame();
            }
        }
    }
}
