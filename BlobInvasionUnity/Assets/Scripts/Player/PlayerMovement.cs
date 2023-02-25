using System;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<bool> OnPlayerMove;

        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rb;

        private bool _isWalking = false;
        private bool IsWalking
        {
            get => _isWalking;
            set
            {
                _isWalking = value;
                OnPlayerMove?.Invoke(_isWalking);
            }
        }

        private void FixedUpdate()
        {
            var _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            if (_direction == Vector3.zero)
            {
                if(IsWalking)
                    IsWalking = false;
            }
            else
            {
                transform.forward = _direction;
                _rb.velocity = _direction * _speed;

                if (!IsWalking)
                    IsWalking = true;
            }
        }
    }
}
