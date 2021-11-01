using UnityEngine;

namespace Aezakmi
{
    public class CameraFollow : MonoBehaviour
    {
        private const float STACK_HEIGHT = .2f;

        [SerializeField] private float _followSpeed;
        private Vector3 _targetPosition;
        private bool firstTap = true;

        private void Start()
        {
            _targetPosition = transform.position;
            EventManager.current.onTapped += ChangeHeight;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _targetPosition, _followSpeed * Time.deltaTime);
        }

        private void ChangeHeight()
        {
            if (!firstTap)
                _targetPosition += Vector3.up * STACK_HEIGHT;
            else
                firstTap = false;
        }
    }
}
