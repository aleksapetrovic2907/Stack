using UnityEngine;

namespace Aezakmi.Stack
{
    public class SliceBehaviour : MonoBehaviour
    {
        private const float ERROR_MARGIN_DISTANCE = .05f;

        private Movement _movement;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }

        public void Slice(Vector3 lastPosition, Vector3 lastScale)
        {
            _movement.CanMove = false;
            var dir = _movement.ReverseDirection ? -1 : 1;

            if (_movement.MovingOnZ)
            {
                var difference = transform.position.z - lastPosition.z;
                if (Mathf.Abs(difference) > lastScale.z)
                {
                    EventManager.current.Missed();
                    gameObject.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    return;
                }
                else if (Mathf.Abs(difference) <= ERROR_MARGIN_DISTANCE)
                {
                    transform.position = new Vector3(lastPosition.x, transform.position.y, lastPosition.z);
                    EventManager.current.Perfect();
                    return;
                }

                var isBehindStack = IsBetween(lastPosition.z, 0, transform.position.z, _movement.ReverseDirection) ? -1 : 1;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, lastScale.z - Mathf.Abs(difference));
                transform.position -= Vector3.forward * difference / 2;

                var edgeOfStack = dir * transform.localScale.z / 2;
                var widthOfLeftover = Mathf.Abs(difference);
                CreateLeftover(new Vector3(transform.position.x, transform.position.y, transform.position.z + isBehindStack * (edgeOfStack + dir * widthOfLeftover / 2)),
                               new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(difference)));
            }
            else
            {
                var difference = transform.position.x - lastPosition.x;
                if (Mathf.Abs(difference) > lastScale.x)
                {
                    EventManager.current.Missed();
                    gameObject.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
                    return;
                }
                else if (Mathf.Abs(difference) <= ERROR_MARGIN_DISTANCE)
                {
                    transform.position = new Vector3(lastPosition.x, transform.position.y, lastPosition.z);
                    EventManager.current.Perfect();
                    return;
                }

                var isBehindStack = IsBetween(lastPosition.x, 0, transform.position.x, _movement.ReverseDirection) ? -1 : 1;
                transform.localScale = new Vector3(lastScale.x - Mathf.Abs(difference), transform.localScale.y, transform.localScale.z);
                transform.position -= Vector3.right * difference / 2;

                var edgeOfStack = dir * transform.localScale.x / 2;
                var widthOfLeftover = Mathf.Abs(difference);

                CreateLeftover(new Vector3(transform.position.x + isBehindStack * (edgeOfStack + dir * widthOfLeftover / 2), transform.position.y, transform.position.z)
                             , new Vector3(Mathf.Abs(difference), transform.localScale.y, transform.localScale.z));
            }

            EventManager.current.Correct();
        }

        private void CreateLeftover(Vector3 position, Vector3 scale)
        {
            var leftover = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftover.transform.position = position;
            leftover.transform.localScale = scale;
            leftover.transform.rotation = Quaternion.identity;
            leftover.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            leftover.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
            Destroy(leftover, 5f);
        }

        private bool IsBetween(float num, float a, float b, bool normalDir)
        {
            return (num < b && normalDir) || (num > b && !normalDir);
        }
    }
}


