using BlobInvasion.Collectable.Props.Bonuses.ScriptableObjects;

namespace BlobInvasion.Collectable.Props.Bonuses
{
    public interface IPowerUp
    {
        public PowerUpType Type { get; }
        public void UsePowerUp(IPowerable powerable);
    }
}