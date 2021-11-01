using UnityEngine;
using Aezakmi.Stack;

namespace Aezakmi
{
    public class StackManager : MonoBehaviour
    {
        private const float STACK_HEIGHT = .2f;

        [Header("Spawn Settings")]
        [SerializeField] private GameObject _stackPrefab;
        [SerializeField] private Transform _stacksParent;
        [SerializeField] private Vector3 _stackSpawnPositionZ;
        [SerializeField] private Vector3 _stackSpawnPositionX;
        [SerializeField] private bool _firstSpawnRandomDirection;

        [Space(20)]
        public GameObject LastStack;
        public GameObject CurrentStack;

        private bool _isSpawningZ;
        private bool _isSpawning = true;

        private void Awake()
        {
            _isSpawningZ = _firstSpawnRandomDirection ? (new System.Random()).NextDouble() >= 0.5 : true;
        }

        private void Start()
        {
            EventManager.current.onMissed += delegate
            {
                _isSpawning = false;
                if (CurrentStack != null && CurrentStack.GetComponent<SliceBehaviour>() != null)
                    Destroy(CurrentStack.GetComponent<SliceBehaviour>());
            };
            EventManager.current.onTapped += SpawnStack;
        }

        private void SpawnStack()
        {
            SliceStack();

            if (_isSpawning)
            {
                if (_isSpawningZ)
                {
                    CurrentStack = Instantiate(_stackPrefab, new Vector3(LastStack.transform.position.x, _stackSpawnPositionZ.y, _stackSpawnPositionZ.z), Quaternion.identity, _stacksParent);
                    CurrentStack.GetComponent<Movement>().MovingOnZ = true;
                    CurrentStack.transform.localScale = LastStack.transform.localScale;
                }
                else
                {
                    CurrentStack = Instantiate(_stackPrefab, new Vector3(_stackSpawnPositionX.x, _stackSpawnPositionX.y, LastStack.transform.position.z), Quaternion.identity, _stacksParent);
                    CurrentStack.GetComponent<Movement>().MovingOnZ = false;
                    CurrentStack.transform.localScale = LastStack.transform.localScale;
                }

                _isSpawningZ = !_isSpawningZ;
                _stackSpawnPositionX += Vector3.up * STACK_HEIGHT;
                _stackSpawnPositionZ += Vector3.up * STACK_HEIGHT;
            }
        }

        private void SliceStack()
        {
            if (CurrentStack != null && CurrentStack.GetComponent<SliceBehaviour>() != null)
                CurrentStack.GetComponent<SliceBehaviour>().Slice(LastStack.transform.position, LastStack.transform.localScale);

            LastStack = CurrentStack;
        }
    }
}
