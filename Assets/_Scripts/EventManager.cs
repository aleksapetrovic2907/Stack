using System;
using UnityEngine;

namespace Aezakmi
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager current;

        private void Awake()
        {
            if(current != this) current = this;
        }

        public event Action onTapped;
        public void Tapped()
        {
            if(onTapped != null) onTapped();
        }

        public event Action onMissed;
        public void Missed()
        {
            if(onMissed != null) onMissed();
        }

        public event Action onCorrect;
        public void Correct()
        {
            if(onCorrect != null) onCorrect();
        }

        public event Action onPerfect;
        public void Perfect()
        {
            if(onPerfect != null) onPerfect();
        }
    }
}
