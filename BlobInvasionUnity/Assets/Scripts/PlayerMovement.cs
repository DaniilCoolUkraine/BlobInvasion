using UnityEngine;

namespace BlobInvasion
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private float _speed;

        private Rigidbody rb;
        
        private float _inputY;
        private float _inputX;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _inputX = _joystick.Horizontal;
            _inputY = _joystick.Vertical;
        }

        private void FixedUpdate()
        {
            var _direction = new Vector3(_inputX, 0, _inputY).normalized;
            rb.velocity = _direction * _speed;

            if (_direction != Vector3.zero)
            {
                transform.forward = _direction;
            }
        }
    }
}
