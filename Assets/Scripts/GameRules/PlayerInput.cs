using UnityEngine;

namespace GameRules
{
    public class PlayerInput : MonoBehaviour
    {
        public static PlayerInput singleton;

        private static KeyCode jumpKey = KeyCode.Space;

        public float MoveHorizontal { get; private set; }
        public bool Jump { get; private set; }
        public bool Reset { get; private set; }
        public bool Quit { get; private set; }

        private void Awake()
        {
            // avoids problems if accidently more than one istance exists
            if (singleton == null)
            {
                singleton = this;
            }
        }

        private void Update()
        {
            MoveHorizontal = Input.GetAxis("Horizontal");
            Jump = Input.GetKeyDown(jumpKey);
            Reset = Input.GetKeyDown(KeyCode.R);
            Quit = Input.GetKeyDown(KeyCode.Escape);
        }
    }
}
