using UnityEngine;

namespace Aezakmi
{
    public class GameManager : MonoBehaviour
    {
        #region GLOBAL_ACCESS
        public static GameManager current;

        private void Awake()
        {
            if (current != this) current = this;
        }
        #endregion

        public Vector2 StackReversePositions; // x being the minimum, y being the maximum

        private void Start()
        {
            // InputManager.OnTap += delegate { Debug.Log("works"); };
        }
    }
}
