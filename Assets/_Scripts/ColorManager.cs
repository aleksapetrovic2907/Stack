using UnityEngine;
using Aezakmi.UI;
using System;

namespace Aezakmi
{
    public class ColorManager : MonoBehaviour
    {
        [SerializeField] private Color _color;
        [SerializeField] private BackgroundColor _backgroundColor;
        [SerializeField] private GameObject[] _baseStacks;

        [Header("Stack Settings")]
        [SerializeField] private Transform _stacks;
        [SerializeField] private float _hueChangePerStack;
        [SerializeField] private float _saturationChangePerStack;
        [SerializeField] private float _brightnessChangePerStack;
        [Range(0f, 1f)] [SerializeField] private float _saturationMin, _saturationMax;
        [Range(0f, 1f)] [SerializeField] private float _brightnessMin, _brightnessMax;

        

        private float _hueDirection, _satDirection, _briDirection;

        private void Awake()
        {
            _hueDirection = (new System.Random().NextDouble() >= 0.5)? 1f : -1f;
            _satDirection = (new System.Random().NextDouble() >= 0.5)? 1f : -1f;
            _briDirection = (new System.Random().NextDouble() >= 0.5)? 1f : -1f;

            SetRandomStartColor();

            foreach (var baseStack in _baseStacks)
            {
                baseStack.GetComponent<Renderer>().material.color = _color;
            }
            _backgroundColor.TargetColor = _color;
        }


        private void Start()
        {
            EventManager.current.onTapped += SetStackColor;
        }
        
        private void SetRandomStartColor()
        {
            Color.RGBToHSV(_color, out var h, out var s, out var v);

            var randomH = UnityEngine.Random.Range(0f, 1f);
            _color = Color.HSVToRGB(randomH, s, v);
            _backgroundColor.SetStartColor(randomH, s, v);
        }

        private void SetStackColor()
        {
            UpdateColor();

            if (_stacks.childCount > 0)
                _stacks.GetChild(_stacks.childCount - 1).GetComponent<Renderer>().material.color = _color;
        }

        private void UpdateColor()
        {
            Color.RGBToHSV(_color, out var h, out var s, out var v);

            if(s + _satDirection * _saturationChangePerStack / 100f > _saturationMax || s + _satDirection * _saturationChangePerStack / 100f < _saturationMin)
                _satDirection *= -1f;

            if(v + _briDirection * _brightnessChangePerStack / 100f > _brightnessMax || v + _briDirection * _brightnessChangePerStack / 100f < _brightnessMin)
                _briDirection *= -1f;

            s += _satDirection * _saturationChangePerStack / 100f;
            v += _briDirection * _brightnessChangePerStack / 100f;

            _color = Color.HSVToRGB(h + _hueDirection * _hueChangePerStack / 100f, s, v);

            _backgroundColor.TargetColor = _color;
        }
    }
}


