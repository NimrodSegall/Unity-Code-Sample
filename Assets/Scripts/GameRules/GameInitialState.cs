using System.Collections.Generic;
using UnityEngine;

namespace GameRules
{
    public class GameInitialState : MonoBehaviour
    {
        public static GameInitialState singleton;

        private static Dictionary<IRemoveable, Vector3> initialPositions = new Dictionary<IRemoveable, Vector3>();
        private static Player.Player player;
        private static Vector3 playerStartingPos, playerStartingScale;

        private void Awake()
        {
            // avoids problems if accidently more than one istance exists
            if (singleton == null)
            {
                singleton = this;
            }
        }

        private void Start()
        {
            GameEvents.singleton.onResetGame += ResetGame;
        }

        public void AddRemoveable(IRemoveable removable)
        {
            initialPositions[removable] = Utils.MathUtils.Vector3Copy(removable.GetPosition());
        }

        public void LogPlayer(Player.Player currentPlayer)
        {
            player = currentPlayer;
            playerStartingPos = Utils.MathUtils.Vector3Copy(player.transform.position);
            playerStartingScale = Utils.MathUtils.Vector3Copy(player.transform.localScale);
        }

        public void ResetGame()
        {
            foreach (IRemoveable removeable in initialPositions.Keys)
            {
                removeable.Reset(initialPositions[removeable]);
            }
            player.ResetPlayer(playerStartingPos, playerStartingScale);
        }
    }
}
