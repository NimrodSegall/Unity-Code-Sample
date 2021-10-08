using UnityEngine;
using GameRules;

namespace Environment
{
    public class CupcakeCollision : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == GameParameters.singleton.PlayerTag)
            {
                GameEvents.singleton.PlayerMunch();
                Eaten();
            }
        }

        private void Eaten()
        {
            gameObject.SetActive(false);
        }
    }
}
