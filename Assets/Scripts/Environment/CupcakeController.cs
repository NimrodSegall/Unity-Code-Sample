using UnityEngine;
using GameRules;

namespace Environment
{
    public class CupcakeController : MonoBehaviour, IRemoveable
    {
        [SerializeField]
        private float speed = 2.5f;
        [SerializeField]
        private float searchGroundDistance = 0.1f;
        [SerializeField]
        private Transform groundDetectionPoint;

        private static readonly int[] startingDirs = new int[] { -1, 1 };

        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            GameInitialState.singleton.AddRemoveable(this);
            SetStartingDirection();
        }

        void Update()
        {
            if (IsNearEdge())
                FlipDirection();
            Move();
        }

        private void SetStartingDirection()
        {
            int dirChoice = startingDirs[Random.Range(0, 2)];                             // -1 or 1
            Vector3 scaleMultiplier = new Vector3(dirChoice, 1, 1);
            transform.localScale = Vector3.Scale(transform.localScale, scaleMultiplier);  // Element wise multiplication
        }

        private bool IsNearEdge()
        {
            if (groundDetectionPoint != null)
            {
                RaycastHit2D hit = Physics2D.Raycast(groundDetectionPoint.position, -groundDetectionPoint.up,
                    searchGroundDistance, GameParameters.singleton.GroundLayerMask);
                return !hit;
            }
            return false;
        }

        private void FlipDirection()
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
        }

        private void Move()
        {
            if (rb != null)
            {
                rb.velocity = new Vector3(speed * transform.localScale.x, rb.velocity.y, 0);
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void Reset(Vector3 originalPosition)
        {
            gameObject.SetActive(true);
            transform.position = originalPosition;
            SetStartingDirection();
        }
    }
}
