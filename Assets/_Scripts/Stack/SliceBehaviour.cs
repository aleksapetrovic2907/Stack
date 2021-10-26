using UnityEngine;

namespace Aezakmi.Stack
{
    public class SliceBehaviour : MonoBehaviour
    {
        private Movement _movement;
        private Color32 _color;

        private void Awake()
        {
            _movement = GetComponent<Movement>();
            _color = GetComponent<Renderer>().material.color;
        }

        public void Slice(Vector3 lastPosition, Vector3 lastScale)
        {
            _movement.CanMove = false;

            if (_movement.MovingOnZ)
            {
                var difference = transform.position.z - lastPosition.z;
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, lastScale.z - Mathf.Abs(difference));
                transform.position -= Vector3.forward * difference / 2;

                var dir = _movement.ReverseDirection ? -1 : 1;
                CreateLeftover(new Vector3(transform.position.x, transform.position.y, (transform.position.z + dir * transform.localScale.z / 2) + difference / 2)
                             , new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(difference)));
            }
            else
            {
                var difference = transform.position.x - lastPosition.x;
                transform.localScale = new Vector3(lastScale.x - Mathf.Abs(difference), transform.localScale.y, transform.localScale.z);
                transform.position -= Vector3.right * difference / 2;

                var dir = _movement.ReverseDirection ? -1 : 1;
                CreateLeftover(new Vector3((transform.position.x + dir * transform.localScale.x / 2) + difference / 2, transform.position.y, transform.position.z)
                             , new Vector3(Mathf.Abs(difference), transform.localScale.y, transform.localScale.z));
            }
        }

        private void CreateLeftover(Vector3 position, Vector3 scale)
        {
            var leftover = GameObject.CreatePrimitive(PrimitiveType.Cube);
            leftover.GetComponent<Collider>().enabled = false;
            leftover.transform.position = position;
            leftover.transform.localScale = scale;
            leftover.transform.rotation = Quaternion.identity;
            leftover.GetComponent<Renderer>().material.color = _color;
            leftover.AddComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        }
    }
}
