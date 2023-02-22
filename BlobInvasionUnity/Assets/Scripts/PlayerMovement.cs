using UnityEngine;

namespace BlobInvasion
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private float _speed;

        //code style _
        private Rigidbody rb;

        //remove fields
        private float _inputY;
        private float _inputX;

        //GetComponent change to [SerializeField]
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        //remove Update
        private void Update()
        {
            //remove fields
            _inputX = _joystick.Horizontal;
            _inputY = _joystick.Vertical;
        }

        private void FixedUpdate()
        {
            var _direction = new Vector3(_inputX, 0, _inputY).normalized;

            //move down to if
            rb.velocity = _direction * _speed;

            if (_direction != Vector3.zero)
            {
                transform.forward = _direction;
            }
        }
    }
}
