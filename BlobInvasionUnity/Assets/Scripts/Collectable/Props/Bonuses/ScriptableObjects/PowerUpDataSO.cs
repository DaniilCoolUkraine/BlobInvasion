using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewPowerUpData", menuName = "ScriptableObjects/PowerUpData", order = 0)]
    public class PowerUpDataSO : ScriptableObject
    {
        [SerializeField] private float _poweringTime;
        [SerializeField] private int _characteristicMultiplier;

        public float PoweringTime => _poweringTime;
        public int CharacteristicMultiplier => _characteristicMultiplier;
    }
}