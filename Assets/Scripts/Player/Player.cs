using UnityEngine;
using GameRules;

namespace Player
{
    public class Player : MonoBehaviour
    {
        private PlayerController controller;
        private PlayerAnimator playerAnimator;
        private PlayerAudio playerAudio;

        void Start()
        {
            controller = GetComponent<PlayerController>();
            playerAnimator = GetComponent<PlayerAnimator>();
            playerAudio = GetComponent<PlayerAudio>();

            GameEvents.singleton.onPlayerMunch += Munch;
            GameInitialState.singleton.LogPlayer(this);
        }

        void Update()
        {
            Move();

            if (PlayerInput.singleton.Jump)
                Jump();

            if (PlayerInput.singleton.Reset)
                ResetGame();

            if (PlayerInput.singleton.Quit)
                Application.Quit();
        }

        private void Move()
        {
            if (controller != null)
            {
                float horizontalSpeed = controller.Move(PlayerInput.singleton.MoveHorizontal);
                if (playerAnimator != null)
                {
                    playerAnimator.Move(horizontalSpeed);
                }
            }
        }

        private void Jump()
        {
            if (controller != null)
            {
                bool jumpSuccessful = controller.Jump();
                if (playerAnimator != null && jumpSuccessful)
                {
                    playerAnimator.Jump();
                }
            }
        }

        private void Munch()
        {
            if (playerAudio != null)
            {
                playerAudio.Munch();
            }
        }

        private void ResetGame()
        {
            GameEvents.singleton.ResetGame();
        }

        public void ResetPlayer(Vector3 startingPos, Vector3 startingScale)
        {
            transform.position = startingPos;
            transform.localScale = startingScale;
            if (controller != null)
            {
                controller.Reset();
            }
        }
    }
}
