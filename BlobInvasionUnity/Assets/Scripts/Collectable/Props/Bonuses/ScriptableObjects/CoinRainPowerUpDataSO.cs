using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewCoinRainPowerUpData", menuName = "ScriptableObjects/CoinRainPowerUpData", order = 0)]
    public class CoinRainPowerUpDataSO : PowerUpDataSO
    {
        [SerializeField] private GameObject _coin;
        [SerializeField] private float _explosionStrength;
       
        public GameObject Coin => _coin;
        public float ExplosionStrength => _explosionStrength;
        
    }
}