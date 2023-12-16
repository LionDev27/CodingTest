using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodingTest.Buttons
{
    public class ButtonColor : MonoBehaviour
    {
        [SerializeField] private List<Color> _colorsInOrder;
        private int _currentIndex;
        private Image _image;
        private ButtonInputs _inputs;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _inputs = GetComponent<ButtonInputs>();
        }
        
        private void OnEnable()
        {
            _inputs.OnRightClick += ChangeColor;
        }

        private void OnDisable()
        {
            _inputs.OnRightClick -= ChangeColor;
        }

        private void Start()
        {
            SetColor();
        }

        private void ChangeColor()
        {
            if (_currentIndex < _colorsInOrder.Count - 1)
                _currentIndex++;
            else
                _currentIndex = 0;
            SetColor();
        }

        private void SetColor()
        {
            _image.color = _colorsInOrder[_currentIndex];
        }
    }
}