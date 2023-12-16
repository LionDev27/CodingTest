using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodingTest.Buttons
{
    public class ButtonInputs : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Action OnLeftClick;
        public Action OnRightClick;
        public Action OnLeftDrag;

        private ButtonClickTimer _clickTimer;
        private bool _mouseOn;
        private bool _dragging;
        
        private void Awake()
        {
            _clickTimer = GetComponent<ButtonClickTimer>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonUp(0) && _dragging)
                _dragging = false;
            if (!_mouseOn) return;
            CheckInputs();
        }

        private void FixedUpdate()
        {
            if (_dragging)
                OnLeftDrag?.Invoke();
        }

        private void CheckInputs()
        {
            CheckClicks();
            CheckDrag();
        }

        private void CheckClicks()
        {
            if (Input.GetMouseButtonUp(1))
                OnRightClick?.Invoke();
            else if (Input.GetMouseButtonUp(0) && _clickTimer.IsClick())
                OnLeftClick?.Invoke();
        }

        private void CheckDrag()
        {
            if (Input.GetMouseButton(0) && !_clickTimer.IsClick())
                _dragging = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _mouseOn = true;
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            _mouseOn = false;
        }
    }
}