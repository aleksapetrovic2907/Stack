using UnityEngine;
using UnityEngine.UI;

namespace Aezakmi.UI
{
    public class BackgroundColor : MonoBehaviour
    {
        [SerializeField] private float _lerpSpeed;
        [Range(0f, 1f)] [SerializeField] private float _saturation;
        [HideInInspector] public Color TargetColor;

        private Image _image;
        private Color _targetColor;
        private float h, s, v;
        private float targetH, targetV;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Update()
        {
            Color.RGBToHSV(TargetColor, out h, out s, out v);

            targetH = Mathf.Lerp(targetH, h, _lerpSpeed * Time.deltaTime);
            targetV = Mathf.Lerp(targetV, v, _lerpSpeed * Time.deltaTime);

            _targetColor = Color.HSVToRGB(targetH, _saturation, targetV);
            _image.color = _targetColor;
        }

        public void SetStartColor(float h, float s, float v)
        {
            _image.color = Color.HSVToRGB(h, _saturation, v);
            _targetColor = _image.color;
            targetH = h;
            targetV = v;
        }
    }
}
