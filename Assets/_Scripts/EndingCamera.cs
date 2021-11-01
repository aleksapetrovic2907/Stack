using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace Aezakmi
{
    public class EndingCamera : MonoBehaviour
    {
        private const float ZOOM_PER_STACK = 0.17153f;
        private const float OFFSET_Y = 4.5f;
        [SerializeField] private float _zoomDuration;
        [SerializeField] private Ease _ease;

        [SerializeField] private Transform _stacks;
        [SerializeField] private GameObject _endCanvas;
        private CameraFollow _cameraFollow;
        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _cameraFollow = GetComponent<CameraFollow>();
        }

        private void Start()
        {
            EventManager.current.onMissed += delegate { StartCoroutine(EndingCameraCoroutine()); };
        }

        private IEnumerator EndingCameraCoroutine()
        {
            Destroy(_cameraFollow);

            yield return new WaitForSecondsRealtime(.3f);


            // Camera size formula y = 11.92489 + (2.055864 - 11.92489)/(1 + (x/78.69163)^2.232337)
            var targetSize = 2 * (11.92489f + ((2.055864f - 11.92489f) /
                                               (1 + Mathf.Pow((_stacks.childCount - 1) / 78.69163f, 2.232337f))));
            _camera.DOOrthoSize(targetSize, _zoomDuration).SetEase(_ease)
                .OnComplete(delegate { _endCanvas.SetActive(true); }).Play();
        }
    }
}