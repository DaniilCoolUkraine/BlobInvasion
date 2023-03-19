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
            // Calculate the direction from the object to the camera
            Vector3 directionToCamera = _mainCamera.transform.position - transform.position;

            // Convert the direction vector into a rotation
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera, Vector3.up);

            // Apply the rotation to the object
            transform.rotation = targetRotation;
        }
    }
}