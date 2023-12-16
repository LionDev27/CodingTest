using TMPro;
using UnityEngine;

namespace CodingTest.Buttons
{
    /// <summary>
    /// Acción de botón que activa otros objetos.
    /// </summary>
    public class ButtonActionActivator : MonoBehaviour
    {
        [SerializeField] protected GameObject _object;
        [SerializeField] protected TextMeshProUGUI _textField;
        [Tooltip("Mensaje que aparecerá en el espacio de texto.")]
        [TextArea]
        [SerializeField] protected string _message;
        
        protected void EnableObject(bool value)
        {
            _object.SetActive(value);
        }
        
        protected void SetMessage(string message)
        {
            _textField.SetText(message);
        }
    }
}