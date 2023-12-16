using System;

namespace CodingTest.Buttons
{
    public class ButtonPopup : ButtonActionActivator
    {
        private ButtonInputs _inputs;

        private void Awake()
        {
            _inputs = GetComponent<ButtonInputs>();
        }

        private void OnEnable()
        {
            _inputs.OnLeftClick += ShowPopup;
        }

        private void OnDisable()
        {
            _inputs.OnLeftClick -= ShowPopup;
        }

        private void Start()
        {
            if (_object.activeInHierarchy)
                EnableObject(false);
        }

        private void ShowPopup()
        {
            SetMessage(_message);
            EnableObject(true);
        }
    }
}
