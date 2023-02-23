using System;
using UnityEngine;

namespace BlobInvasion
{
    public class PlayerMovement : MonoBehaviour
    {
        public event Action<Animator, bool> OnPlayerMove;

        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rb;

        [SerializeField] private Animator _animator;

        private bool _isWalking = false;

        private void FixedUpdate()
        {
            var _direction = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;

            if (_direction != Vector3.zero)
            {
                transform.forward = _direction;
                _rb.velocity = _direction * _speed;

                if (!_isWalking)
                {
                    //move to function
                    _isWalking = true;
                    OnPlayerMove?.Invoke(_animator, _isWalking);
                }
            }
            else
            {
                //Invoke this each frame when player simply standing. todo might be optimized
                //add if(_isWalking))
                //move to function
                _isWalking = false;
                OnPlayerMove?.Invoke(_animator, _isWalking);
            }
        }
    }
}
