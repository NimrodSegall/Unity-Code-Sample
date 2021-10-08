using UnityEngine;
using System.Collections;
using GameRules;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float searchGroundDistance = 0.1f;
        [SerializeField]
        private float jumpStrength = 1f;
        [SerializeField]
        private float jumpCooldown = 0.1f;
        [SerializeField]
        private float speed = 1f;
        [SerializeField]
        private Transform[] groundPoints;

        private Rigidbody2D rb;
        private bool isOnJumpCooldown = false;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private bool IsGrounded()
        {
            if (groundPoints != null)
            {
                if (groundPoints.Length > 0)
                {
                    foreach (Transform groundPoint in groundPoints)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(groundPoint.position, -groundPoint.up, searchGroundDistance,
                            GameParameters.singleton.GroundLayerMask);
                        if (hit)
                            return true;
                    }
                }
            }
            return false;
        }

        // Prevents quickly tapping the jump key from allowing multiple jumps
        private IEnumerator JumpCooldownCo()
        {
            isOnJumpCooldown = true;
            yield return new WaitForSeconds(jumpCooldown);
            isOnJumpCooldown = false;
            yield return null;
        }

        public bool Jump()
        {
            if (rb == null)
                return false;
            if (isOnJumpCooldown)
                return false;

            if (IsGrounded())
            {
                rb.AddForce(new Vector2(0, jumpStrength), ForceMode2D.Impulse);
                StartCoroutine("JumpCooldownCo");
                return true;
            }
            return false;
        }

        public float Move(float baseVelocity)
        {
            if (rb != null)
            {
                rb.velocity = new Vector2(baseVelocity * speed, rb.velocity.y);
            }
            return rb.velocity.x;
        }

        public void Reset()
        {
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
