using UnityEngine;

namespace BlobInvasion.General
{
    public class RotateTowardsCamera : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        void Update()
        {
            Vector3 directionToCamera = _mainCamera.transform.position - transform.position;
            
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);
            
            transform.rotation = targetRotation;
        }
    }
}