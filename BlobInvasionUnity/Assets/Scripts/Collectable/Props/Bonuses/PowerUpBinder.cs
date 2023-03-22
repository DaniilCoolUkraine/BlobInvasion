using System.Linq;
using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;
using UnityEngine;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public class PowerUpBinder : MonoBehaviour
    {
        [System.Serializable]
        public class PowerUpEntity
        {
            [SerializeField] private PowerUpType _type;
            [SerializeField] private Component _powerUp;

            public PowerUpType Type => _type;
            public Component PowerUp => _powerUp;
        }

        [SerializeField] private PowerUpEntity[] _powerUpEntities;

        public IPowerable GetPowerUp(PowerUpType type)
        {
            // todo add check for null
            return _powerUpEntities.FirstOrDefault(x => x.Type == type).PowerUp as IPowerable;
        }
    }
}