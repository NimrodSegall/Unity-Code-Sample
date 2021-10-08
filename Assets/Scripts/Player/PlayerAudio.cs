using UnityEngine;

namespace Player
{
    public class PlayerAudio : MonoBehaviour
    {
        private AudioSource munchSoundSource;
        void Start()
        {
            munchSoundSource = GetComponent<AudioSource>();
        }

        public void Munch()
        {
            if (munchSoundSource != null)
            {
                munchSoundSource.Play();
            }
        }
    }
}
