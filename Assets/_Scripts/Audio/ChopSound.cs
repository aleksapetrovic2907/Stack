using UnityEngine;

namespace Aezakmi
{
    public class ChopSound : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _woodChops;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            EventManager.current.onCorrect += PlayWoodChop;
        }

        private void PlayWoodChop()
        {
            var random = Random.Range(0, _woodChops.Length);
            _audioSource.PlayOneShot(_woodChops[random]);
        }
    }
}
