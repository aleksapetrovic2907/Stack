using UnityEngine;

namespace Aezakmi.Audio
{
    public class StreakSound : MonoBehaviour
    {
        private const float SEMITONE_FREQ = 1.05946f;
        // private const float MAX_FREQ = 2.24483f;
        [SerializeField] private AudioClip _streak;

        private AudioSource _audioSource;

        private void Awake() => _audioSource = GetComponent<AudioSource>();
        private void Start() => EventManager.current.onPerfect += PlayStreak;

        private void PlayStreak()
        {
            var streak = GameManager.current.currentStreak - 1;
            var octave = streak / 7;
            int n;

            // C Major Scale
            switch (streak % 7)
            {
                case 0: n = 0; break;
                case 1: n = 2; break;
                case 2: n = 4; break;
                case 3: n = 5; break;
                case 4: n = 7; break;
                case 5: n = 9; break;
                case 6: n = 11; break;
                default: n = 0; break;
            }

            var pitch = Mathf.Pow(SEMITONE_FREQ, (float)n + (octave * 12));
            // if (pitch >= MAX_FREQ) pitch = MAX_FREQ;

            _audioSource.pitch = pitch;
            _audioSource.PlayOneShot(_streak);
        }
    }
}



