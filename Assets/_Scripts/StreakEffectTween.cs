using UnityEngine;
using DG.Tweening;
namespace Aezakmi
{
    public class StreakEffectTween : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration;

        private SpriteRenderer _spriteRenderer;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer
                .DOColor(new Color32(255, 255, 255, 0), _fadeDuration)
                .OnComplete(delegate
            {
                Destroy(gameObject);
            }).Play();
        }
    }
}
