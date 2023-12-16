using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodingTest.Buttons
{
    public class ButtonClickTimer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Tooltip("Tiempo que se usará para saber si es un click o si se está manteniendo pulsado el click.")]
        [Range(0.1f, 0.5f)]
        [SerializeField] private float _clickDelay = 0.25f;
        private bool _clickUp;
        private float _timer;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _clickUp = false;
            StartCoroutine(ClickDelayTimer());
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _clickUp = true;
        }

        public bool IsClick()
        {
            return _timer <= _clickDelay;
        }

        private IEnumerator ClickDelayTimer()
        {
            _timer = 0;
            while (!_clickUp)
            {
                _timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}