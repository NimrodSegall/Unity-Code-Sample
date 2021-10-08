using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]
        private float jumpResetDuration = 0.1f;
        [SerializeField]
        private float minSpeedToFlipDirection = 0.05f;
        [SerializeField]
        private string isJumpingVarName = "isJumping";
        [SerializeField]
        private string horizontalSpeedVarName = "horizontalSpeed";

        private Vector3 originalScale = Vector3.one;
        private Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
            GetOriginalScale();
        }

        private void GetOriginalScale()
        {
            originalScale = transform.localScale;
        }

        private IEnumerator ResetJumpBool()
        {
            // Reset jump animator boolean shortly after jumping
            yield return new WaitForSeconds(jumpResetDuration);
            animator.SetBool(isJumpingVarName, false);
            yield return null;
        }

        public void Jump()
        {
            // Handle jump animation
            if (animator != null)
            {
                animator.SetBool(isJumpingVarName, true);
                StartCoroutine("ResetJumpBool");
            }
        }

        public void Move(float velocity)
        {
            // Handle run animation
            float speed = Mathf.Abs(velocity);
            if (animator != null)
            {
                animator.SetFloat(horizontalSpeedVarName, speed);
            }

            // Handle direction flip
            if (speed > minSpeedToFlipDirection)
            {
                float signVelocity = Mathf.Sign(velocity);
                transform.localScale = Vector3.Scale(originalScale, new Vector3(signVelocity, 1, 1)); // Element wise multiplication
            }
        }
    }
}
