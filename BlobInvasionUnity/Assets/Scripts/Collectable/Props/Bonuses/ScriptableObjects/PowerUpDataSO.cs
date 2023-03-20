using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPowerUpData", menuName = "ScriptableObjects/PowerUpData", order = 0)]
    public class PowerUpDataSO : ScriptableObject
    {
        [SerializeField] private int _powerMultiplier;
        [SerializeField] private float _poweringTime;

        public int PowerMultiplier => _powerMultiplier;
        public float PoweringTime => _poweringTime;
    }
}