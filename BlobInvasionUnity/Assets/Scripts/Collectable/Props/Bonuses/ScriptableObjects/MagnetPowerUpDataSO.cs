using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewMagnetPowerUpData", menuName = "ScriptableObjects/MagnetPowerUpData", order = 0)]
    public class MagnetPowerUpDataSO: PowerUpDataSO
    {
        [SerializeField] private float _maxDistance;
        public float MaxDistance => _maxDistance;
    }
}