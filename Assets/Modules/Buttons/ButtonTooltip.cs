using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodingTest.Buttons
{
    public class ButtonTooltip : ButtonActionActivator, IPointerEnterHandler, IPointerExitHandler
    {
        [Tooltip("Tiempo que tardará en aparecer dicho mensaje.")]
        [SerializeField] private float _delay;

        private void Start()
        {
            SetMessage(_message);
            if (_object.activeInHierarchy)
                EnableObject(false);
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            StartCoroutine(ShowTooltipWithDelay());
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
            EnableObject(false);
        }

        private IEnumerator ShowTooltipWithDelay()
        {
            yield return new WaitForSeconds(_delay);
            EnableObject(true);
        }
    }
}