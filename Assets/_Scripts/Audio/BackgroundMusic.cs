using UnityEngine;

namespace Aezakmi.Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        public static BackgroundMusic current;

        private void Awake()
        {
            if (current != null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            current = this;
        }
    }
}