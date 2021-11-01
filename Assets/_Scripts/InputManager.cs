using System;
using UnityEngine;

namespace Aezakmi
{
    public class InputManager : MonoBehaviour
    {
        private Touch _touch;

        private void Update()
        {
            if (Input.touchCount > 0)
            {
                _touch = Input.GetTouch(0);
                if (_touch.phase == TouchPhase.Began)
                    EventManager.current.Tapped();
            }

            if (Input.GetKeyDown(KeyCode.Space))
                EventManager.current.Tapped();
        }
    }
}
