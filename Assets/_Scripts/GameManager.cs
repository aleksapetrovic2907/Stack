using UnityEngine;
using UnityEngine.Serialization;

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

        [SerializeField] private StackManager _stackManager;

        public Vector2 stackReversePositions; // x being the minimum, y being the maximum
        public int currentPoints = 0;
        public int currentStreak = 0;
        private void Start()
        {
            EventManager.current.onCorrect += Correct;
            EventManager.current.onPerfect += Perfect;
            EventManager.current.onMissed += Missed;
        }

        private void Correct()
        {
            currentPoints++;
            currentStreak = 0;
        }

        private void Perfect()
        {
            currentStreak++;
            currentPoints ++;
        }

        private void Missed()
        {
            Destroy(_stackManager.gameObject);
            
            if(currentPoints > GlobalData.Highscore) GlobalData.Highscore = currentPoints;
        }
    }
}
