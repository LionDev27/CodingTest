using UnityEngine;

namespace CodingTest.Buttons
{
    public class ButtonMover : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private ButtonInputs _inputs;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputs = GetComponent<ButtonInputs>();
        }

        private void OnEnable()
        {
            _inputs.OnLeftDrag += Move;
        }

        private void OnDisable()
        {
            _inputs.OnLeftDrag -= Move;
        }

        private void Move()
        {
            _rigidbody.MovePosition(Input.mousePosition);
        }
    }
}