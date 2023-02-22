using UnityEngine;

namespace BlobInvasion
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private float _speed;

        [SerializeField] private Rigidbody _rb;

        private void FixedUpdate()
        {
            var _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            if (_direction != Vector3.zero)
            {
                transform.forward = _direction;
                _rb.velocity = _direction * _speed;
            }
        }
    }
}
