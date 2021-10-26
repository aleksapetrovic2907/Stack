using UnityEngine;

namespace Aezakmi.Stack
{
    public class Movement : MonoBehaviour
    {
        public float MoveSpeed;
        public bool MovingOnZ = true;
        public bool CanMove = true;
        public bool ReverseDirection = false;

        private void Update()
        {
            if (CanMove)
            {
                CheckIfCorrectDirection();
                if(MovingOnZ) MoveOnZ();
                else MoveOnX();
            }
        }

        private void CheckIfCorrectDirection()
        {
            if(MovingOnZ)
            {
                if(transform.position.z > GameManager.current.StackReversePositions.y) ReverseDirection = true;
                else if(transform.position.z < GameManager.current.StackReversePositions.x) ReverseDirection = false;
            }
            else
            {
                if(transform.position.x > GameManager.current.StackReversePositions.y) ReverseDirection = true;
                else if(transform.position.x < GameManager.current.StackReversePositions.x) ReverseDirection = false;
            }
        }

        private void MoveOnZ()
        {
            if(ReverseDirection)
                transform.position += Vector3.back * MoveSpeed * Time.deltaTime;
            else
                transform.position += Vector3.forward * MoveSpeed * Time.deltaTime;
        }

        private void MoveOnX()
        {
            if(ReverseDirection)
                transform.position += Vector3.left * MoveSpeed * Time.deltaTime;
            else
                transform.position += Vector3.right * MoveSpeed * Time.deltaTime;
        }
    }
}
