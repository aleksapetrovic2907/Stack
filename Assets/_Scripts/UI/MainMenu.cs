using UnityEngine;
using DG.Tweening;

namespace Aezakmi.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private GameObject _pointsCanvas;

        private void Start()
        {
            EventManager.current.onTapped += LeaveMenu;
        }

        private void LeaveMenu()
        {
            GetComponent<CanvasGroup>().DOFade(0f, _fadeDuration).OnComplete(delegate
            {
                EventManager.current.onTapped -= LeaveMenu;
                _pointsCanvas.SetActive(true);
                Destroy(gameObject);
            }).Play();
        }
    }
}
