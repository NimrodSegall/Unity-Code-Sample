using UnityEngine;
using GameRules;

namespace Environment
{
    public class Boundary : MonoBehaviour
    {
        [SerializeField]
        private Transform teleportHeight;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GameParameters.singleton.PlayerTag)
            {
                if (teleportHeight != null)
                {
                    Vector3 playerPos = collision.transform.position;
                    collision.transform.position = new Vector3(playerPos.x, teleportHeight.position.y, 0);
                }
            }
        }
    }
}
