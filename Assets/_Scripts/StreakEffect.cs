using UnityEngine;

namespace Aezakmi
{
    public class StreakEffect : MonoBehaviour
    {
        private const float STACK_HEIGHT = .2f;
        [SerializeField] private Transform _stacks;
        [SerializeField] private GameObject _effectPrefab;
        [SerializeField] private float _effectPadding;

        private void Start()
        {
            EventManager.current.onPerfect += PlayEffect;
        }

        private void PlayEffect()
        {
            var lastStack = _stacks.GetChild(_stacks.childCount - 1);
            var lastStackPosition = lastStack.transform.position - Vector3.up * (STACK_HEIGHT / 2f);

            var effect = Instantiate(_effectPrefab, lastStackPosition, _effectPrefab.transform.rotation);
            effect.transform.localScale = new Vector3(lastStack.localScale.x + _effectPadding, lastStack.localScale.z + _effectPadding, 1f);
        }
    }
}
