using System;
using System.Collections;
using BlobInvasion.Collectable.Props.Bonuses;
using UnityEngine;

namespace BlobInvasion.Player
{
    public class MoveByPhysicsJoysticController : MonoBehaviour, IPowerable
    {
        public event Action<bool> OnPlayerMove;
        public bool IsActive { get; set; }

        [SerializeField] private float _speed;
        [SerializeField] private bool _isMove = true;
        [SerializeField] private bool _isRotation = true;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _intervalRotation = 0.1f;

        private Vector3 _axisRotation = new Vector3(0, 1, 0);
        private Vector3 _direction;
        private WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate();
        private Coroutine _rotationCoroutine;
        private Coroutine _moveCoroutine;
        private Vector3 _refVelocity = Vector3.zero;
        private float _smoothVal = .2f; // Higher = 'Smoother'

        public bool IsMove { get => _isMove; set => _isMove = value; }
        public bool IsRotation { get => _isRotation; set => _isRotation = value; }
        public float Speed { set { _speed = value; } }

        protected virtual void OnEnable()
        {
             _joystick.OnInterract += SetActive;
        }
        
        protected virtual void OnDisable()
        {
             _joystick.OnInterract -= SetActive;
        }
        
        protected virtual void SetActive(bool isActive)
        {
            if (IsMove)
            {
                SetActiveMove(isActive);
            }

            if (IsRotation)
            {
                SetActiveRotation(isActive);
            }
        }

        protected virtual void SetActiveMove(bool isActive)
        {
            if (_moveCoroutine != null)
            {
                StopCoroutine(_moveCoroutine);
            }

            if (isActive && _joystick.IsDirectionNotZero)
            {
                _moveCoroutine = StartCoroutine(MoveCoroutine());
                OnPlayerMove?.Invoke(true);
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                OnPlayerMove?.Invoke(false);
            }
        }

        protected virtual IEnumerator MoveCoroutine()
        {
            while (true)
            {
                yield return _waitForFixedUpdate;
                _direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;

                var speedLimit = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);

                if (speedLimit.magnitude < _speed)
                {
                    _rigidbody.velocity = Vector3.SmoothDamp(
                        _rigidbody.velocity,
                        _direction * _speed, ref _refVelocity, _smoothVal);
                }
            }
        }

        protected virtual void SetActiveRotation(bool isActive)
        {
            if (_rotationCoroutine != null)
            {
                StopCoroutine(_rotationCoroutine);
            }

            if (isActive && _joystick.IsDirectionNotZero)
            {
                _rotationCoroutine = StartCoroutine(RotationCoroutine());
            }
            else
            {
                _rigidbody.angularVelocity = Vector3.zero;
            }
        }

        protected virtual IEnumerator RotationCoroutine()
        {
            while (true)
            {
                yield return _waitForFixedUpdate;
                float destinationAngle = Mathf.Atan2(_joystick.Horizontal, _joystick.Vertical) * Mathf.Rad2Deg;
                var destinationRotation = Quaternion.Euler(new Vector3(0, destinationAngle, 0));

                var delta = destinationRotation * Quaternion.Inverse(_rigidbody.rotation);

                float angle;

                delta.ToAngleAxis(out angle, out _axisRotation);

                if (!float.IsInfinity(_axisRotation.x))
                {
                    if (angle > 180f)
                        angle -= 360f;

                    Vector3 angular = (0.9f * Mathf.Deg2Rad * angle / _intervalRotation) * _axisRotation.normalized;

                    _rigidbody.angularVelocity = angular;
                }
            }
        }
        
        public void Apply(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _speed += (int) param[0];
        }

        public void Discard(params object[] param)
        {
            if (param == null || param.Length == 0 || !(param[0] is float))
            {
                return;
            }
            
            _speed -= (int) param[0];
        }
    }
}
