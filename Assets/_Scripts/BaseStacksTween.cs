using UnityEngine;
using DG.Tweening;

namespace Aezakmi
{
    public class BaseStacksTween : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        // Start is called before the first frame update
        private void Start()
        {
            transform.DOMoveY(0f, _duration).SetEase(_ease).Play();
        }
    }
}
