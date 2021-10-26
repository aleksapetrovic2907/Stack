using System;
using UnityEngine;

namespace Aezakmi
{
    public class InputManager : MonoBehaviour
    {
        public static event Action OnTap;
        private Touch _touch;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Began)
                    if (OnTap != null) OnTap();
            }

            if (Input.GetKeyDown(KeyCode.Space))
                if (OnTap != null) OnTap();
        }
    }
}
