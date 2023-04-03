using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewMagnetPowerUpData", menuName = "ScriptableObjects/MagnetPowerUpData", order = 0)]
    public class MagnetPowerUpDataSO: PowerUpDataSO
    {
        [SerializeField] private GameObject _playerCollector;
        [SerializeField] private float _magnetStrength;
        
        public GameObject PlayerCollector => _playerCollector;
        public float MagnetStrength => _magnetStrength;
    }
}