using UnityEngine;
using System.Collections.Generic;

namespace GameRules
{
    public class GameParameters : MonoBehaviour
    {
        public static GameParameters singleton;
        [SerializeField]
        public int GroundLayerMask { get; private set; } = 1 << 8;
        [SerializeField]
        public string PlayerTag { get; private set; } = "Player";
        [SerializeField]
        public string RemoveablesTag { get; private set; } = "Removeables";
        [SerializeField]
        public int CupcakeScoreValue { get; private set; } = 1;

        private void Awake()
        {
            // avoids problems if accidently more than one istance exists
            if (singleton == null)
            {
                singleton = this;
            }
        }
    }
}
