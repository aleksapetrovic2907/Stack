using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace Aezakmi.UI
{
    public class GameOverCanvas : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration;
        private bool allowReload = false;
        private void Start()
        {
            GetComponent<CanvasGroup>().DOFade(1f, _fadeDuration).OnComplete(delegate { allowReload = true; }).Play();
            EventManager.current.onTapped += ReloadScene;
        }

        private void ReloadScene()
        {
            if(allowReload)
                SceneManager.LoadScene(0);
        }
    }
}
