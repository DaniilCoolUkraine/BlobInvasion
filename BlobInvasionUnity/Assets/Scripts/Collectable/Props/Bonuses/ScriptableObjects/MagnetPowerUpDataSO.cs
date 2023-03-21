using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewMagnetPowerUpData", menuName = "ScriptableObjects/MagnetPowerUpData", order = 0)]
    public class MagnetPowerUpDataSO: PowerUpDataSO
    {
        [SerializeField] private GameObject _playerCollector;
        public GameObject PlayerCollector => _playerCollector;
    }
}