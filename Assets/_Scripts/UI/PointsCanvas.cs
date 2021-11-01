using UnityEngine;
using TMPro;
using DG.Tweening;

namespace Aezakmi.UI
{
    public class PointsCanvas : MonoBehaviour
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private TextMeshProUGUI _points;
        [SerializeField] private TextMeshProUGUI _highscore;

        private void Start()
        {
            GetComponent<CanvasGroup>().DOFade(1f, _fadeDuration).Play();
            _highscore.text = GlobalData.Highscore.ToString();
            EventManager.current.onCorrect += UpdateScore;
            EventManager.current.onPerfect += UpdateScore;
        }

        private void UpdateScore() => _points.text = GameManager.current.currentPoints.ToString();
    }
}
