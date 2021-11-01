using UnityEngine;
using TMPro;

namespace Aezakmi.UI
{
    public class HighscoreCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _highscore;

        private void Start()
        {
            _highscore.text = GlobalData.Highscore.ToString();
        }
    }
}
