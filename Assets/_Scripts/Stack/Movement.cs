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
            if (!CanMove) return;

            CheckIfCorrectDirection();
            if (MovingOnZ) MoveOnZ();
            else MoveOnX();
        }

        private void CheckIfCorrectDirection()
        {
            if (MovingOnZ)
            {
                if (transform.position.z > GameManager.current.stackReversePositions.y) ReverseDirection = true;
                else if (transform.position.z < GameManager.current.stackReversePositions.x) ReverseDirection = false;
            }
            else
            {
                if (transform.position.x > GameManager.current.stackReversePositions.y) ReverseDirection = true;
                else if (transform.position.x < GameManager.current.stackReversePositions.x) ReverseDirection = false;
            }
        }

        private void MoveOnZ()
        {
            if (ReverseDirection)
                transform.position += Time.deltaTime * MoveSpeed * Vector3.back;
            else
                transform.position += Time.deltaTime * MoveSpeed * Vector3.forward;
        }

        private void MoveOnX()
        {
            if (ReverseDirection)
                transform.position += Time.deltaTime * MoveSpeed * Vector3.left;
            else
                transform.position += Time.deltaTime * MoveSpeed * Vector3.right;
        }
    }
}