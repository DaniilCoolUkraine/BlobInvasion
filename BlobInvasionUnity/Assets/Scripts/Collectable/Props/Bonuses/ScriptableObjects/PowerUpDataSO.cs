using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPowerUpData", menuName = "ScriptableObjects/PowerUpData", order = 0)]
    public class PowerUpDataSO : ScriptableObject
    {
        [SerializeField] private float _powerMultiplier;
        [SerializeField] private float _poweringTime;

        public float PowerMultiplier => _powerMultiplier;
        public float PoweringTime => _poweringTime;
    }
}